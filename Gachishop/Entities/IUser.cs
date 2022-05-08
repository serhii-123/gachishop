using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public interface IUser
{
    [Key]
    int Id { get; set; }
    string Username { get; set; }
    string Password { get; set; }
    string Name { get; set; }
    string Surname { get; set; }
    bool IsAdmin { get; set; }
    int Discount { get; set; }
}