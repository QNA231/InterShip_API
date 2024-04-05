using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("Food_tbl")]
    public class Food
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string NameOfFood { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<BillFood>? BillFoods { get; set; }
    }
}
