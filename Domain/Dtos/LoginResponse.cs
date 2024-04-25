namespace Domain.Dtos
{
    public class LoginResponse
    {
        public LoginResponse()
        {
            this.Token = string.Empty;
            this.ResponseMsg =
            new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized
            };
        }
        public string Token { get; set; }
        public HttpResponseMessage ResponseMsg { get; set; }
    }
}
