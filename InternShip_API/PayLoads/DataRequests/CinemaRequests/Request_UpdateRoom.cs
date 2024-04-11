using InternShip_API.Entities;
using InternShip_API.PayLoads.DataRequests.SeatRequests;

namespace InternShip_API.PayLoads.DataRequests.CinemaRequests
{
    public class Request_UpdateRoom
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public int CinemaId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Cinema Cinema { get; set; }
        public List<Request_UpdateSeat>? request_CreateSeats { get; set; }
    }
}
