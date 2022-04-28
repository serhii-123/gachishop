using System;
using Gachishop;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        UserContext userContext = new UserContext();
        
        userContext.Users.Add(new User("Van", "123123123", true, 20));
        Console.WriteLine("Hello, world");
    }
}