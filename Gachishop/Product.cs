using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class Product : IProduct
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public int Discount { get; set; }
    
    public Product(string name, string description, string type, int price, int quantity, int discount)
    {
        Name = name;
        Description = description;
        Type = type;
        Price = price;
        Quantity = quantity;
        Discount = discount;
    }
}