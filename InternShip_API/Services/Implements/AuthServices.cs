using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.Handels.HandleEmail;
using InternShip_API.PayLoads.Converters;
using InternShip_API.PayLoads.DataRequests.AuthRequests;
using InternShip_API.PayLoads.DataRequests.UserRequests;
using InternShip_API.PayLoads.DataResponses;
using InternShip_API.PayLoads.Responses;
using InternShip_API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using BcryptNet = BCrypt.Net.BCrypt;

namespace InternShip_API.Services.Implements
{
    public class AuthServices : IAuthServices
    {
        private readonly AppDbContext dbContext;
        private readonly ResponseObject<DataResponse_User> responseObject;
        private readonly IConfiguration configuration;
        private readonly UserConverter converter;
        private readonly ResponseObject<DataResponse_Token> responseTokenObject;

        public AuthServices(ResponseObject<DataResponse_User> responseObject, IConfiguration configuration, UserConverter converter, ResponseObject<DataResponse_Token> responseTokenObject)
        {
            dbContext = new AppDbContext();
            this.responseObject = responseObject;
            this.configuration = configuration;
            this.converter = converter;
            this.responseTokenObject = responseTokenObject;
        }

        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var item = RandomNumberGenerator.Create())
            {
                item.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }

        public DataResponse_Token GenerateAccessToken(User user)
        {
            var jwtTokenHandle = new JwtSecurityTokenHandler();
            var secretKeyBytes = System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:SecretKey").Value);
            var role = dbContext.Roles.SingleOrDefault(x => x.Id == user.RoleId);
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("TenQuyen", role.RoleName),
                    new Claim(ClaimTypes.Role, role.Code),
                }),
                Expires = DateTime.Now.AddDays(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = jwtTokenHandle.CreateToken(tokenDesc);
            var accessToken = jwtTokenHandle.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            RefreshToken rf = new RefreshToken
            {
                Token = refreshToken,
                ExpiredTime = DateTime.Now.AddDays(1),
                UserId = user.Id,
            };
            dbContext.RefreshTokens.Add(rf);
            dbContext.SaveChanges();
            DataResponse_Token result = new DataResponse_Token
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
            return result;
        }

        public ResponseObject<DataResponse_Token> Login(Request_Login request)
        {
            var user = dbContext.Users.SingleOrDefault(x => x.UserName == request.UserName);
            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.PassWord))
            {
                return responseTokenObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng điền đủ thông tin", null);
            }
            bool checkPass = BcryptNet.Verify(request.PassWord, user.PassWord);
            if (!checkPass)
            {
                return responseTokenObject.ResponseError(StatusCodes.Status400BadRequest, "Mật khẩu không đúng", null);
            }
            return responseTokenObject.ResponseSuccess("Đăng nhập thành công", GenerateAccessToken(user));
        }

        public DataResponse_Token RenewAccessToken(Request_RenewAccessToken request)
        {
            throw new NotImplementedException();
        }

        public ResponseObject<DataResponse_User> Register(Request_Register request)
        {
            if(string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.PhoneNumBer) || string.IsNullOrWhiteSpace(request.PassWord))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Vui lòng điền đủ thông tin", null);
            }
            if (!IsValid.IsValidEmail(request.Email))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Định dạng email không hợp lệ", null);
            }
            if (!IsValid.IsValidPhoneNumber(request.PhoneNumBer))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Định dạng số điện thoại không hợp lệ", null);
            }
            if(dbContext.Users.Any(x => x.UserName == request.UserName))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Tên người dùng đã tồn tại", null);
            }
            if (dbContext.Users.Any(x => x.Email == request.Email))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Email đã tồn tại", null);
            }
            if (dbContext.Users.Any(x => x.PhoneNumBer == request.PhoneNumBer))
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Số điện thoại đã tồn tại", null);
            }
            User user = new User();
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PhoneNumBer = request.PhoneNumBer;
            user.Name = request.Name;
            user.PassWord = BcryptNet.HashPassword(request.PassWord);
            user.RoleId = 3;
            user.UserStatusId = 1;
            user.IsActive = false;
            ConfirmEmail confirmEmail = new ConfirmEmail
            {
                UserId = user.Id,
                ExpiredTime = DateTime.Now.AddHours(2),
                ConfirmCode = GeneraterCodeActive().ToString(),
            };
            dbContext.Add(confirmEmail);
            dbContext.SaveChanges();

            dbContext.Add(user);
            dbContext.SaveChanges();
            return responseObject.ResponseSuccess("Đăng ký thành công", converter.EntityToDTO(user));
        }

        private int GeneraterCodeActive()
        {
            Random rand = new Random();
            return rand.Next(100000, 999999);
        }

        private void SendEmail(string toEmail)
        {
            SmtpClient smtpClient = new SmtpClient("", 587); // mail 
            smtpClient.Credentials = new NetworkCredential("", "");
            smtpClient.EnableSsl = true;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("anhquan23122003@gmail.com");
            mailMessage.To.Add(""); // mail người nhận
            mailMessage.Subject = "Mã xác thực";
            mailMessage.Body = $"{GeneraterCodeActive}. Mã có hiệu lực trong 2 tiếng";

            try
            {
                smtpClient.Send(mailMessage);

            }
            catch(Exception ex)
            {
            }
        }

        private void UpdatePassInDb(int userId, string hashedNewPass)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                user.PassWord = hashedNewPass;
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                // Mã hóa mật khẩu người dùng cung cấp
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                // Chuyển đổi giá trị băm thành một chuỗi hexa
                string hashedInputPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                // So sánh giá trị băm với giá trị băm đã được lưu trữ
                if (hashedInputPassword == hashedPassword)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public ResponseObject<DataResponse_User> ChangePassWord(Request_ChangePassWord request, int userId)
        {
            var currentUser = dbContext.Users.FirstOrDefault(x => x.Id == userId);
            if(currentUser != null)
            {
                if (VerifyPassword(request.CurrentPass, currentUser.PassWord))
                {
                    string hashedNewPass = BcryptNet.HashPassword(request.NewPass);
                    UpdatePassInDb(currentUser.Id, hashedNewPass);
                    return responseObject.ResponseSuccess("Đổi mật khẩu thành công", converter.EntityToDTO(currentUser));
                }
                else
                {
                    return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Mật khẩu cũ không đúng", null);
                }
            }
            else
            {
                return responseObject.ResponseError(StatusCodes.Status400BadRequest, "Người dùng không tồn tại", null);
            }
        }
    }
}
