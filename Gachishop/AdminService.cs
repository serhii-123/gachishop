using Microsoft.EntityFrameworkCore;

namespace Gachishop;

public class AdminService : IAdminService
{
    private string[] _productTypes;

    public AdminService(string[] productTypes)
    {
        _productTypes = productTypes;
    }
    public void Start()
    {
        bool done = false;
        string enteredText;
        
        while (!done)
        {
            Console.WriteLine("Доступные команды: \nДобавить товар\nВыйти");
            enteredText = CustomInput.ReadText();

            switch (enteredText)
            {
                case("Добавить товар"):
                    AddProduct();
                    break;
                case("Выйти"):
                    done = true;
                    break;
            }
        }
    }

    private void AddProduct()
    {
        string name, description, type;
        int price, quantity, discount;
        
        Console.WriteLine("Введите имя товара");
        name = CustomInput.ReadText();
        Console.WriteLine("Введите описание товара");
        description = CustomInput.ReadText();
        Console.WriteLine("Введите тип товара");
        type = CustomInput.ReadText();
        
        if (!_productTypes.Contains(type)) {
            Console.WriteLine("Невозможно добавить товар с таким типом. Введите другой тип");
            while (true)
            {
                type = CustomInput.ReadText();
                if (!_productTypes.Contains(type))
                {
                    Console.WriteLine("Невозможно добавить товар с таким типом. Введите другой тип");
                }
                else break;
            }
        }
        
        Console.WriteLine("Введите цену товара");
        price = CustomInput.ReadNumber();
        Console.WriteLine("Введите количество единиц товара");
        quantity = CustomInput.ReadNumber();
        Console.WriteLine("Введите скидку на товар");
        discount = CustomInput.ReadNumber();
        Console.WriteLine("Товар добавлен");
        using (ProductContext ctx = new ProductContext())
        {
            Product newProduct = new Product(name, description, type, price, quantity, discount);
            ctx.Products.Add(newProduct);
            ctx.SaveChanges();
        }
    }
}