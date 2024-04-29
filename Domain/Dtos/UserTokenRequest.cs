namespace Domain.Dtos
{
    public class UserTokenRequest
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public short RoleType { get; set; }

    }
}
