using System.Text.RegularExpressions;

namespace InternShip_API.Handels.HandleEmail
{
    public class IsValid
    {
        public static bool IsValidEmail(string email)
        {
            // Biểu thức chính quy để kiểm tra địa chỉ email
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Sử dụng lớp Regex để kiểm tra địa chỉ email với biểu thức chính quy
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Biểu thức chính quy để kiểm tra số điện thoại
            string pattern = @"^(?:(?:\+|0{0,2})84|0)(?:3[2-9]|5[689]|7[0|6-9]|8[1-9]|9[0-9])\d{7}$";

            // Sử dụng lớp Regex để kiểm tra số điện thoại với biểu thức chính quy
            Regex regex = new Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }
    }
}
