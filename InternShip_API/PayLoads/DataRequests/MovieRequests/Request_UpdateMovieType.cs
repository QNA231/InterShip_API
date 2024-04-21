using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataRequests.MovieRequests
{
    public class Request_UpdateMovieType
    {
        public int Id { get; set; }
        public string MovieTypeName { get; set; }
    }
}
