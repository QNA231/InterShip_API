using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataRequests.SeatRequests
{
    public class Request_UpdateSeat
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int SeatStatusId { get; set; }
        public string Line { get; set; }
        public int RoomId { get; set; }
        public int SeatTypeId { get; set; }
        //public IEnumerable<Ticket>? Tickets { get; set; }
    }
}
