using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("Movie_tbl")]
    public class Movie
    {
        public int Id { get; set; }
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
        public bool IsActive { get; set; }
        public MovieType MovieType { get; set; }
        public Rate Rate { get; set; }
        public IEnumerable<Schedule>? Schedules { get; set; }
    }
}
