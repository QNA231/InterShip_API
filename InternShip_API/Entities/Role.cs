using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table ("Role_tbl")]
    public class Role
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<User>? Users { get; set; }
    }
}
