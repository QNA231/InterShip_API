using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("Rate_tbl")]
    public class Rate
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public IEnumerable<Movie>? Movies { get; set; }
    }
}
