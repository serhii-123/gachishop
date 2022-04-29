using System;
using Gachishop;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        UserContext userContext = new UserContext();
        userContext.Database.EnsureCreated();
        userContext.Users.Add(new User("Van", "123123123", true, 20));
        userContext.SaveChanges();
        Console.WriteLine("Hello, world");
    }
}