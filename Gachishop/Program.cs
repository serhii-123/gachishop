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
        loginService.Login();
        if (loginService.AuthorizedUser.IsAdmin)
        {
            adminService.Start();
        }
    }
}