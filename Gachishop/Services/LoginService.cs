using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gachishop
{
    internal class LoginService
    {
       public User AuthorizedUser { get; set; }
       public void Login()
        {
            using(ShopContext ctx = new ShopContext())
            {
                IEnumerable<User> list = ctx.Users.ToList();
                while(true)
                {
                    Console.WriteLine("Enter username:");
                    string name = CheckName();
                    Console.WriteLine("Enter password:");
                    string password = CheckPassword();
                    User user = list.FirstOrDefault(u => (u.Username == name) && (u.Password == password));
                    if (user == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong name or password");
                        
                    }
                    else
                    {
                        AuthorizedUser = user;
                        return;
                    }
                }
            }
        }
        static string CheckPassword()
        {
            try
            {
                string enteredVal = "";

                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        enteredVal += key.KeyChar;
                        Console.Write("*");
                        continue;
                    }

                    if (key.Key == ConsoleKey.Backspace && enteredVal.Length != 0)
                    {
                        enteredVal = enteredVal.Substring(0, (enteredVal.Length - 1));
                        Console.Write("\b \b");
                        continue;
                    }

                    if (key.Key == ConsoleKey.Enter && !string.IsNullOrWhiteSpace(enteredVal))
                    {
                        Console.WriteLine("");
                        return enteredVal;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error");
                return "";
            }
        }
        static string CheckName()
        {
            try
            {
                string enteredVal = "";

                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        enteredVal += key.KeyChar;
                        Console.Write(key.KeyChar);
                        continue;
                    }

                    if (key.Key == ConsoleKey.Backspace && enteredVal.Length != 0)
                    {
                        enteredVal = enteredVal.Substring(0, (enteredVal.Length - 1));
                        Console.Write("\b \b");
                        continue;
                    }

                    if (key.Key == ConsoleKey.Enter && !string.IsNullOrWhiteSpace(enteredVal))
                    {
                        Console.WriteLine("");
                        return enteredVal;
                    }
                }
            }
            catch
            {
                return "";
            }
        }
    }
}   

