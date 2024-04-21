using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataResponses
{
    public class DataResponse_BillTicket
    {
        public int Quantity { get; set; }
        public int SeatNumber { get; set; }
        public string SeatLine { get; set; }
    }
}
