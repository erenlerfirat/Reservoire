using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    internal class LoginService : ILoginService
    {
        public void Login(string username, string password)
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
            throw new NotImplementedException();
        }

        public void UpdatePassword(string username, string password)
        {
            // check jwt and update user password
            throw new NotImplementedException();
        }
    }
}
