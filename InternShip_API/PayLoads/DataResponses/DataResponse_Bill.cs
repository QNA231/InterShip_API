using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataResponses
{
    public class DataResponse_Bill
    {
        public double? TotalMoney { get; set; }
        public string TradingCode { get; set; }
        public DateTime CreateTime { get; set; }
        public string CustomerName { get; set; }
        public string Name { get; set; }
        public int? PromotionPercent { get; set; }
        public string BillStatusName { get; set; }
        public IQueryable<DataResponse_BillFood>? BillFoods { get; set; }
        public IQueryable<DataResponse_BillTicket>? BillTickets { get; set; }
    }
}
