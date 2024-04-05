using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("BillStatus_tbl")]
    public class BillStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Bill>? Bills { get; set; }
    }
}
