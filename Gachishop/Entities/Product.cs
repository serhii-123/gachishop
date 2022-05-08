using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class Product : IProduct
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Discount { get; set; }
    public int CategoryId { get; set; }
    public int InventoryId { get; set; }
    
    public Product(string name, string description, int price, int discount)
    {
        Name = name;
        Description = description;
        Price = price;
        Discount = discount;
    }
}