using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataRequests.PromotionRequests
{
    public class Request_CreatePromotion
    {
        public int Percent { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int RankCustomerId { get; set; }
    }
}
