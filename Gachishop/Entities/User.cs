using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class User : IUser
{
    [Key]
    public int Id { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public bool IsAdmin { get; set; }
    public int Discount { get; set; }

    public User(string username, string password, string name, string surname, bool isAdmin, int discount)
    {
        Username = username;
        Password = password;
        Name = name;
        Surname = surname;
        IsAdmin = isAdmin;
        Discount = discount;
    }
}