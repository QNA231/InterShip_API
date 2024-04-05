using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("Room_tbl")]
    public class Room
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
        public IEnumerable<Seat>? Seats { get; set; }
        public IEnumerable<Schedule>? Schedules { get; set; }
    }
}
