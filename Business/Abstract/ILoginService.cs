namespace Business.Abstract
{
    public interface ILoginService
    {
        public void Login(string email, string password);
        public void Logout(string username);
        public void Register(string username,string password, string email);
        public void UpdatePassword(string username, string password);
    }
}
