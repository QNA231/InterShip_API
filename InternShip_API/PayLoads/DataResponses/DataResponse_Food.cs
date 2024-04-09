using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataResponses
{
    public class DataResponse_Food
    {
        public double Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string NameOfFood { get; set; }
    }
}
