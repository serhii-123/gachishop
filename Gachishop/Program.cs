using System;
using Gachishop;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        string[] productTypes = { "Bondage", "Latex glove" };
        AdminService adminService = new AdminService(productTypes);
        LoginService loginService = new LoginService();
        loginService.Login();
        
        if (loginService.AuthorizedUser.IsAdmin)
        {
            adminService.Start();
        }
    }
}