using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class Product : IProduct
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }

    public int Price
    {
        get
        {
            return _price;
        }
        set
        {
            if (value != 0)
            {
                _price = value;
            }
            else throw new Exception("Value is 0");
        }
    }
    public int Quantity
    {
        get
        {
            return _quantity;
        }
        set
        {
            if (value != 0)
            {
                _quantity = value;
            }
            else throw new Exception("Value is 0");
        }
    }

    public int Discount
    {
        get
        {
            return _discount;
        }
        set
        {
            if (value <= 100)
            {
                _discount = value;
            }
            else throw new Exception("Value is bigger than 100");
        }
    }

    private int _price;
    private int _quantity;
    private int _discount;
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