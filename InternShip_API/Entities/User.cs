using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("User_tbl")]
    public class User
    {
        public int Id { get; set; }
        public int? Point { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumBer { get; set; }
        public string PassWord { get; set; }
        public int? RankCustomerId { get; set; }
        public int UserStatusId { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public UserStatus UserStatus { get; set; }
        public Role Role { get; set; }
        public RankCustomer RankCustomer { get; set; }
        public IEnumerable<RefreshToken>? RefreshTokens { get; set; }
        public IEnumerable<ConfirmEmail>? ConfirmEmails { get; set; }
        public IEnumerable<Bill>? Bills { get; set; }
    }
}
