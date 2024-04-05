using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("SeatType_tbl")]
    public class SeatType
    {
        public int Id { get; set; }
        public string NameType { get; set; }
        public IEnumerable<Seat>? Seats { get; set; }
    }
}
