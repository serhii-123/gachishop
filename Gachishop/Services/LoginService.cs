using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gachishop
{
    class LoginService : ILoginService
    {
        private ShopContext _ctx;

        public LoginService(ShopContext ctx)
        {
            _ctx = ctx;
        }
        public User FindUser(string name, string password)
        {
            IEnumerable<User> list = _ctx.Users.ToList();

            return list.FirstOrDefault(u => (u.Username == name) && (u.Password == password));
        }
    }
}