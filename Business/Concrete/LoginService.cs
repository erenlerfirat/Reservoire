using Business.Abstract;
using Domain.Models;
using Utiliy.Abstract;
namespace Business.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly CoreDbContext context;
        private readonly IHashHelper hashHelper;
        public LoginService(CoreDbContext context, IHashHelper hashHelper)
        {
            this.context = context;
            this.hashHelper = hashHelper;
        }
        public void Login(string email, string password)
        {
            // go check user credentials
            // create jwt token
            

            throw new NotImplementedException();
        }

        public void Logout(string username)
        {
            //
            throw new NotImplementedException();
        }

        public void Register(string username, string password, string email)
        {
            // add user credentials to table
            string hash = hashHelper.Encrypt(password);
            User user = new() { Email = email, PasswordHash = hash };
            context.User.Add(user);
            context.SaveChanges();
        }

        public void UpdatePassword(string username, string password)
        {
            // check jwt and update user password
            throw new NotImplementedException();
        }
    }
}
