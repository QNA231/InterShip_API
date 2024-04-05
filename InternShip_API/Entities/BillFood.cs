using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("BillFood_tbl")]
    public class BillFood
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BillId { get; set; }
        public int FoodId { get; set; }
        public Bill Bill { get; set; }
        public Food Food { get; set; }
    }
}
