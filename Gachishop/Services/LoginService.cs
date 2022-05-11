using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gachishop
{
    class LoginService : ILoginService
    {
        public User FindUser(string name, string password)
        {
            using (ShopContext ctx = new ShopContext())
            {
                IEnumerable<User> list = ctx.Users.ToList();

                return list.FirstOrDefault(u => (u.Username == name) && (u.Password == password));
            }
        }
    }
}   

