namespace Domain.Dtos
{
    public class LoginRequest
    {
        public LoginRequest()
        {
            this.UserName = string.Empty;
            this.Password = string.Empty;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
