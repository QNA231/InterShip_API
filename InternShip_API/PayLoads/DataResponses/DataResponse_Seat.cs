using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataResponses
{
    public class DataResponse_Seat
    {
        public int Number { get; set; }
        public string SeatStatusName { get; set; }
        public string Line { get; set; }
        public string RoomName { get; set; }
        public string SeatTypeName { get; set; }
        //public IEnumerable<Ticket>? Tickets { get; set; }
    }
}
