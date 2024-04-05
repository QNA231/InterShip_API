using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("MovieType_tbl")]
    public class MovieType
    {
        public int Id { get; set; }
        public string MovieTypeName { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Movie>? Movies { get; set; }
    }
}
