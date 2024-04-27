namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public int UserRoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int PhoneNumber { get; set; }
        public int FailedTryCount { get; set; }
    }
}
