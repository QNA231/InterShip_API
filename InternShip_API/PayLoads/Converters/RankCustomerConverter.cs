using InternShip_API.DataContext;
using InternShip_API.Entities;
using InternShip_API.PayLoads.DataResponses;

namespace InternShip_API.PayLoads.Converters
{
    public class RankCustomerConverter
    {
        public DataResponse_RankCustomer EntityToDTO(RankCustomer rankCustomer)
        {
            return new DataResponse_RankCustomer
            {
                Point = rankCustomer.Point,
                Description = rankCustomer.Description,
                Name = rankCustomer.Name,
            };
        }
    }
}
