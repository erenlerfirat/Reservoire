using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILoginService
    {
        public void Login(string username, string password);
        public void Logout(string username);
        public void Register(string username,string password, string email);
        public void UpdatePassword(string username, string password);
    }
}
