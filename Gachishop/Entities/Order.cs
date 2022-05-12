using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class Order
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Total { get; set; }

    public Order(int userId, int total)
    {
        UserId = userId;
        Total = total;
    }
}