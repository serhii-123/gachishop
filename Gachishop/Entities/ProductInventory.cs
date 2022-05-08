using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class ProductInventory : IProductInventory
{
    [Key]
    public int Id { get; set; }
    public int Quantity { get; set; }

    public ProductInventory(int quantity)
    {
        Quantity = quantity;
    }
}