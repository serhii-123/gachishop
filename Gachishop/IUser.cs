using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public interface IUser
{
    [Key]
    int Id { get; set; }
    string Name { get; set; }
    string Password { get; set; }
    bool IsAdmin { get; set; }
    bool CheckAccess(string name, string password);
}