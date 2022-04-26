using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class User : IUser
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
    public int Discount { get; set; }
    public bool CheckAccess(string name, string password)
    {
        return (Name == name) && (Password == password);
    }
}