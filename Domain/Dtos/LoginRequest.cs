namespace Domain.Dtos
{
    public class LoginRequest
    {
        public LoginRequest()
        {
            this.Password = string.Empty;
        }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
