using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataRequests.MovieRequests
{
    public class Request_CreateMovie
    {
        public int MovieDuration { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime PremiereDate { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Image { get; set; }
        public string HeroImage { get; set; }
        public string Language { get; set; }
        public int MovieTypeId { get; set; }
        public string Name { get; set; }
        public int RateId { get; set; }
        public string Traler { get; set; }
    }
}
