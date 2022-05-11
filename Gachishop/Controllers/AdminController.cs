namespace Gachishop.Controllers;

public class AdminController
{
    private IAdminControllerDataParser _dataParser;
    private IAdminService _service;

    public AdminController(IAdminService service, IAdminControllerDataParser dataParser)
    {
        _dataParser = dataParser;
        _service = service;
    }
    
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
        string name = _dataParser.GetProductName();
        string description = _dataParser.GetProductDescription();
        string category = _dataParser.GetProductCategory();
        int price = _dataParser.GetProductPrice();
        int quantity = _dataParser.GetProductQuantity();
        int discount = _dataParser.GetProductDiscount();

        _service.AddProduct(name, description, category, price, quantity, discount);

        Console.WriteLine("Товар добавлен. Нажмите любую клавишу");
        Console.ReadKey();
    }
}