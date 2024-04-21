using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataResponses
{
    public class DataResponse_RankCustomer
    {
        public int Point { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public IQueryable<DataResponse_User> Users { get; set; }
    }
}
