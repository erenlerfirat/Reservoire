using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("UserRole", Schema = "app")]
    public class UserRole : BaseModel
    {
        public int Id { get; set; }
        public short RoleType { get; set; }
        public int UserId { get; set; }
    }
}
