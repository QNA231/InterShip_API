using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataResponses
{
    public class DataResponse_Ticket
    {
        public string Code { get; set; }
        public string ScheduleName { get; set; }
        public int SeatNumber { get; set; }
        public string SeatLine{ get; set; }
        public double PriceTicket { get; set; }
    }
}
