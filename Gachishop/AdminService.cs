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
                case("Выйти"):
                    done = true;
                    break;
            }
        }
    }

    private void AddProduct()
    {
        Console.WriteLine("Введите имя товара");
        string name = CustomInput.ReadText();
        Console.WriteLine("Введите описание товара");
        string description = CustomInput.ReadText();
        Console.WriteLine("Введите тип товара");
        string type = CustomInput.ReadText();
        
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
        int price = CustomInput.ReadNumber();
        
        Console.WriteLine("Товар добавлен, ебана");
    }
}