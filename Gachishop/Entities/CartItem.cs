using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class CartItem
{
    [Key]
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public CartItem(int cartId, int productId, int quantity)
    {
        CartId = cartId;
        ProductId = productId;
        Quantity = quantity;
    }
}