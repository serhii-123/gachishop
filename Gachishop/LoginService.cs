using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gachishop
{
    internal class LoginService
    {
       public IUser AuthorizedUser { get; set; }

        public void Login()
        {
            using (UserContext ctx = new UserContext())
            {
                IEnumerable<User> list = ctx.Users.ToList();
                while(true)
                {
                    Console.WriteLine("Enter name:");
                    string name = CheckName();
                    Console.WriteLine("Enter password:");
                    string password = CheckPassword();
                    User user = list.FirstOrDefault(u => (u.Name == name) && (u.Password == password));
                    if (user == null)
                    {
                        Console.WriteLine("Дурачок.");
                    }
                    else
                    {
                        Console.WriteLine("Welcome to the club buddy");
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

