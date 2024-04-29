namespace Domain.Models
{
    public class UserRole : BaseModel
    {
        public int Id { get; set; }
        public short RoleType { get; set; }
        public int UserId { get; set; }
    }
}
