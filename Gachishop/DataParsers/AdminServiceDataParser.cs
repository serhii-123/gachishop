namespace Gachishop;

public static class AdminServiceDataParser
{
    public static string GetProductName()
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
    public static string GetProductDescription()
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

    public static string GetProductCategory()    
    {
        string type;
        string[] productCategories;
        
        using (ShopContext ctx = new ShopContext())
        {
            productCategories = ctx.ProductCategories.Select(c => c.Name).ToArray();
        }

        Console.WriteLine("Введите категорию товара");
        type = CustomInput.ReadText();
        
        while (true)
        {
            if (!productCategories.Contains(type))
            {
                Console.WriteLine("Неверный тип товара. Введите другой");
                type = CustomInput.ReadText();
            }
            else return type;
        }
    }

    public static int GetProductPrice()
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
    
    public static int GetProductQuantity()
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
    
    public static int GetProductDiscount()
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
            }
            else return discount;
        }
    }
}