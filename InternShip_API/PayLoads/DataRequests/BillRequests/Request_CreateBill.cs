using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataRequests.BillRequests
{
    public class Request_CreateBill
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int? PromotionId { get; set; }
        public List<Request_CreateBillFood>? BillFoods { get; set; }
        public List<Request_CreateBillTicket> BillTickets { get; set; }
    }
}
