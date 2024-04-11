using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataRequests.CinemaRequests
{
    public class Request_UpdateCinema
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string NameOfCinema { get; set; }
        public List<Request_CreateRoom>? request_UpdateRooms { get; set; }
    }
}
