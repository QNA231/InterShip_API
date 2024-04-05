using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class RoleConverter
    {
        private readonly AppDbContext dbContext;
        private readonly UserConverter converter;

        public RoleConverter(UserConverter converter)
        {
            dbContext = new AppDbContext();
            this.converter = converter;
        }
        public DataResponse_Role EntityToDTO(Role role)
        {
            return new DataResponse_Role()
            {
                Code = role.Code,
                RoleName = role.RoleName,
                DataResponseUsers = dbContext.Users.Where(x => x.RoleId == role.Id).Select(x => converter.EntityToDTO(x)),
            };
        }
    }
}
