using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataRequests.BillRequests
{
    public class Request_CreateBillFood
    {
        public int Quantity { get; set; }
        public int FoodId { get; set; }
    }
}
