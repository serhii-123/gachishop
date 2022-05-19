using System;
using Gachishop;
using Gachishop.Controllers;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        
        ShopContext ctx = new ShopContext();
        
        PostalController postalController = new PostalController();
        
        IAdminService adminService = new AdminService(ctx);
        IAdminControllerDataParser adminControllerDataParser = new AdminControllerDataParser(adminService);
        AdminController adminController = new AdminController(adminService, adminControllerDataParser, postalController);

        ILoginService loginService = new LoginService(ctx);
        LoginController loginController = new LoginController(loginService);

        IBuyerService buyerService = new BuyerService(ctx);
        IBuyerControllerDataParser buyerControllerDataParser = new BuyerControllerDataParser(buyerService);
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
                buyerContoller = new BuyerController(loginController.AuthorizedUser, buyerService, buyerControllerDataParser);
                buyerContoller.Start();
            }
        }
    }
}