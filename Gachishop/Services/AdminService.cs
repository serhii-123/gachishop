using Microsoft.EntityFrameworkCore;

namespace Gachishop;

public class AdminService : IAdminService
{
    public void Start()
    {
        bool done = false;
        int enteredNumber;
        while (!done)
        {
            Console.WriteLine("Введите номер команды: \n(1)Добавить товар\n(2)Выйти");
            enteredNumber = CustomInput.ReadNumber();

            switch (enteredNumber)
            {
                case(1):
                    Console.Clear();
                    AddProduct();
                    Console.Clear();
                    break;
                case(2):
                    done = true;
                    break;
                default:
                    Console.WriteLine("Нет команды с данной цифрой");
                    break;
            }
        }
        Console.Clear();
        
    }

    private void AddProduct()
    {
        string name = GetName();
        string description = GetDescription();
        string category = GetCategory();
        int price = GetPrice();
        int quantity = GetQuantity();
        int discount = GetDiscount();

        using (ShopContext ctx = new ShopContext())
        {
            int categoryId = ctx.ProductCategories.First(c => c.Name == category).Id;
            ProductInventory inventory = new ProductInventory(quantity);
            ctx.ProductInventories.Add(inventory);
            ctx.SaveChanges();
            
            Product newProduct = new Product(name, description, price, discount, categoryId, inventory.Id);
            
            ctx.Products.Add(newProduct);
            ctx.SaveChanges();
        }
        
        Console.WriteLine("Товар добавлен. Нажмите любую клавишу");
        Console.ReadKey();
    }

    private string GetName()
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
    private string GetDescription()
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

    private string GetCategory()
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

    private int GetPrice()
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
    
    private int GetQuantity()
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
    
    private int GetDiscount()
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