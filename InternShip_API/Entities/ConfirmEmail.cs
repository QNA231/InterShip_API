using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("ConfirmEmail_tbl")]
    public class ConfirmEmail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ExpiredTime { get; set; }
        public string ConfirmCode { get; set; }
        public bool IsConfirm { get; set; } 
        public User User { get; set; }
    }
}
