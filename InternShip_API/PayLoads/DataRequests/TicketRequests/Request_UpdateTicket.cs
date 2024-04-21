using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataRequests.TicketRequests
{
    public class Request_UpdateTicket
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int SeatId { get; set; }
    }
}
