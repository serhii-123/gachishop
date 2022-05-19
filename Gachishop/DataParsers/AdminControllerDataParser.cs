using Gachishop.Controllers;

namespace Gachishop;

public class AdminControllerDataParser : IAdminControllerDataParser
{
    private IAdminService _service;

    public AdminControllerDataParser(IAdminService service)
    {
        _service = service;
    }
    public string GetProductName()
    {
        string name;
        
        Console.WriteLine("Enter product name");
        name = CustomInput.ReadText();

        while (true)
        {
            if (name.Length < 3)
            {
                Console.WriteLine("Name too short. Try again");
                name = CustomInput.ReadText();
                continue;
            }
            
            return name;
        }
    }
    public string GetProductDescription()
    {
        string description;
        
        Console.WriteLine("Enter product description");
        description = CustomInput.ReadText();

        while (true)
        {
            if (description.Length < 20)
            {
                Console.WriteLine("Description too short. Try again");
                description = CustomInput.ReadText();
                continue;
            }
            
            return description;
        }
    }

    public string GetProductCategoryNameForProduct()    
    {
        string category;
        List<string> productCategories = _service.GetProductCategories();

        Console.WriteLine("Enter product category");
        category = CustomInput.ReadText();
        
        while (true)
        {
            if (!productCategories.Contains(category))
            {
                Console.WriteLine("Wrong category. Try again");
                category = CustomInput.ReadText();
                continue;
            }
            
            return category;
        }
    }

    public int GetProductPrice()
    {
        int price;
        
        Console.WriteLine("Enter price");
        price = CustomInput.ReadNumber();

        while (true)
        {
            if (price == 0)
            {
                Console.WriteLine("The price cannot be zero. Try again");
                price = CustomInput.ReadNumber();
                continue;
            } 
            
            return price;
        }
    }
    
    public int GetProductQuantity()
    {
        int quantity;
        
        Console.WriteLine("Enter product quantity");
        quantity = CustomInput.ReadNumber();

        while (true)
        {
            if (quantity == 0)
            {
                Console.WriteLine("The quantity cannot be zero. Try again");
                quantity = CustomInput.ReadNumber();
                continue;
            }
            
            return quantity;
        }
    }
    
    public int GetProductDiscount()
    {
        int discount;
        
        Console.WriteLine("Enter product discount");
        discount = CustomInput.ReadNumber();

        while (true)
        {
            if (discount > 99)
            {
                Console.WriteLine("Discount cannot be more than 99 percent. Try again");
                discount = CustomInput.ReadNumber();
                continue;
            }
            
            return discount;
        }
    }

    public string GetProductCategoryName()
    {
        string categoryName;
        
        Console.WriteLine("Enter category name");
        categoryName = CustomInput.ReadText();

        while (true)
        {
            if (categoryName.Length < 3)
            {
                Console.WriteLine("Category name too short. Try again");
                categoryName = CustomInput.ReadText();
                continue;
            }

            return categoryName;
        }
    }
}