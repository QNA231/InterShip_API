using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class UserConverter
    {
        private readonly AppDbContext dbContext;

        public UserConverter()
        {
            dbContext = new AppDbContext();
        }
        public DataResponse_User EntityToDTO(User user)
        {
            return new DataResponse_User()
            {
                Name = user.Name,
                UserName = user.UserName,
                PassWord = user.PassWord,
                RoleName = dbContext.Roles.SingleOrDefault(x => x.Id == user.RoleId).RoleName,
            };
        }
    }
}
