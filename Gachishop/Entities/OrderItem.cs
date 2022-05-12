using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class OrderItem
{
    [Key]
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quanity { get; set; }

    public OrderItem(int orderId, int productId, int quanity)
    {
        OrderId = orderId;
        ProductId = productId;
        Quanity = quanity;
    }
}