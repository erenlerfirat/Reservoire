namespace Domain.Dtos
{
    public class LoginResponse
    {
        public LoginResponse()
        {
            Token = string.Empty;
        }
        public string Token { get; set; }
    }
}
