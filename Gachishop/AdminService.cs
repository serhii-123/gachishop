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
        while (!done)
        {
            Console.WriteLine("Доступные команды: \nДобавить товар\nВыйти");
            string enteredText = Console.ReadLine();

            switch (enteredText)
            {
                case("Добавить товар"):
                    AddProduct();
                    break;
                case("Выход"):
                    done = true;
                    break;
            }
        }
    }

    private void AddProduct()
    {
        Console.WriteLine("Введите имя товара");
        string name = Console.ReadLine();
        Console.WriteLine("Введите описание товара");
        string description = Console.ReadLine();
        Console.WriteLine("Введите тип товара");
        string type = Console.ReadLine();
        
        if (!_productTypes.Contains(type)) {
            Console.WriteLine("Невозможно добавить товар с таким типом. Введите другой тип");
            while (true)
            {
                type = Console.ReadLine();
                if (!_productTypes.Contains(type))
                {
                    Console.WriteLine("Невозможно добавить товар с таким типом. Введите другой тип");
                }
                else break;
            }
        }
        
        Console.WriteLine("Введите цену товара");
        int price = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Товар добавлен, ебана");
    }
}