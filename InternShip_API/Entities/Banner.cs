using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("Banner_tbl")]
    public class Banner
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
    }
}
