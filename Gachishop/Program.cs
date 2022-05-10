using System;
using Gachishop;
using Gachishop.Controllers;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        LoginController loginController = new LoginController();
        AdminController adminController = new AdminController();
        BuyerContoller buyerContoller;

        while (true)
        {
            loginController.Login();
            Console.Clear();
            if (loginController.AuthorizedUser.IsAdmin)
            {
                adminController.Start();
            }
            else
            {
                buyerContoller = new BuyerContoller(loginController.AuthorizedUser);
                buyerContoller.Start();
            }
        }
    }
}