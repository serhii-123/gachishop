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
        
        Console.WriteLine("Введите имя товара");
        name = CustomInput.ReadText();

        while (true)
        {
            if (name.Length < 3)
            {
                Console.WriteLine("Слишком короткое имя. Введите другое");
                name = CustomInput.ReadText();
            }
            else return name;
        }
    }
    public string GetProductDescription()
    {
        string description;
        
        Console.WriteLine("Введите описание товара");
        description = CustomInput.ReadText();

        while (true)
        {
            if (description.Length < 20)
            {
                Console.WriteLine("Слишком короткое описание. Введите другое");
                description = CustomInput.ReadText();
            }
            else return description;
        }
    }

    public string GetProductCategoryNameForProduct()    
    {
        string type;
        string[] productCategories = _service.GetProductCategories();

        Console.WriteLine("Введите категорию товара");
        type = CustomInput.ReadText();
        
        while (true)
        {
            if (!productCategories.Contains(type))
            {
                Console.WriteLine("Неверная категория товара. Введите другую");
                type = CustomInput.ReadText();
            }
            else return type;
        }
    }

    public int GetProductPrice()
    {
        int price;
        
        Console.WriteLine("Введите цену товара");
        price = CustomInput.ReadNumber();

        while (true)
        {
            if (price == 0)
            {
                Console.WriteLine("Цена не может быть равна нулю. Введите другую");
                price = CustomInput.ReadNumber();
            }
            else return price;
        }
    }
    
    public int GetProductQuantity()
    {
        int quantity;
        
        Console.WriteLine("Введите кол-во единиц товара");
        quantity = CustomInput.ReadNumber();

        while (true)
        {
            if (quantity == 0)
            {
                Console.WriteLine("Кол-во товаров не может быть равно нулю. Введите другое");
                quantity = CustomInput.ReadNumber();
            }
            else return quantity;
        }
    }
    
    public int GetProductDiscount()
    {
        int discount;
        
        Console.WriteLine("Введите скидку на товар");
        discount = CustomInput.ReadNumber();

        while (true)
        {
            if (discount > 99)
            {
                Console.WriteLine("Скидка не может быть больше 99-ти процентов. Введите другую");
                discount = CustomInput.ReadNumber();
                continue;
            }
            
            return discount;
        }
    }

    public string GetProductCategoryName()
    {
        string categoryName;
        
        Console.WriteLine("Введите имя категории");
        categoryName = CustomInput.ReadText();

        while (true)
        {
            if (categoryName.Length < 3)
            {
                Console.WriteLine("Имя категории слишком короткое. Введите другое");
                categoryName = CustomInput.ReadText();
                continue;
            }

            return categoryName;
        }
    }
}