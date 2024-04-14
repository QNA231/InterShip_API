using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataRequests.TicketRequests
{
    public class Request_CreateTicket
    {
        public string Code { get; set; }
        public int ScheduleId { get; set; }
        public int SeatId { get; set; }
        public double PriceTicket { get; set; }
        public IQueryable<Request_CreateBillTicket>? request_CreateBillTickets { get; set; }
    }
}
