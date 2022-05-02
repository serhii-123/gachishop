using System;
using Gachishop;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        string[] productTypes = { "Latex glove", "Bondage"};
        LoginService loginService = new LoginService();
        AdminService adminService = new AdminService(productTypes);
        BuyerService buyerService;

        while (true)
        {
            loginService.Login();
            Console.Clear();
            if (loginService.AuthorizedUser.IsAdmin)
            {
                adminService.Start();
            }
            else
            {
                buyerService = new BuyerService(loginService.AuthorizedUser);
                buyerService.Start();
            }
        }
    }
}