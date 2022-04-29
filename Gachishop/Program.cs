using System;
using Gachishop;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        LoginService loginService = new LoginService();
        loginService.Login();
    }
}