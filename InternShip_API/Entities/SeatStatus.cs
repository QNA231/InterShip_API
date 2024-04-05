using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("SeatStatus_tbl")]
    public class SeatStatus
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameStatus { get; set; }
        public IEnumerable<Seat>? Seats { get; set; }
    }
}
