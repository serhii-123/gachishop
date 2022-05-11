using System;
using Gachishop;
using Gachishop.Controllers;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        IAdminService adminService = new AdminService();
        IAdminControllerDataParser adminControllerDataParser = new AdminControllerDataParser(adminService);
        AdminController adminController = new AdminController(adminService, adminControllerDataParser);
        
        LoginController loginController = new LoginController();

        BuyerController buyerContoller;

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
                buyerContoller = new BuyerController(loginController.AuthorizedUser);
                buyerContoller.Start();
            }
        }
    }
}