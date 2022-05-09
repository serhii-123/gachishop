using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class Cart
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }

    public Cart(int userId)
    {
        UserId = userId;
    }
}