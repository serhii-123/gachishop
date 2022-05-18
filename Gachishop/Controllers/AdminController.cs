namespace Gachishop.Controllers;

public class AdminController
{
    private IAdminControllerDataParser _dataParser;
    private IAdminService _service;
    private PostalController _postalController;

    public AdminController(IAdminService service, IAdminControllerDataParser dataParser, PostalController postalController)
    {
        _dataParser = dataParser;
        _service = service;
        _postalController = postalController;
    }
    
    public void Start()
    {
        bool done = false;
        int enteredNumber;
        while (!done)
        {
            Console.WriteLine("Введите номер команды: \n" +
                              "(1)Добавить товар \n" +
                              "(2)Добавить категорию \n" +
                              "(3)Обработать заказы \n" +
                              "(4)Выйти");
            enteredNumber = CustomInput.ReadNumber();

            switch (enteredNumber)
            {
                case(1):
                    Console.Clear();
                    AddProduct();
                    Console.WriteLine("Нажмите любую клавишу");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(2):
                    Console.Clear();
                    AddCategory();
                    Console.WriteLine("Нажмите любую клавишу");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(3):
                    Console.Clear();
                    ProcessOrders();
                    Console.WriteLine("Нажмите любую клавишу");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(4):
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
        string category = _dataParser.GetProductCategoryNameForProduct();
        int price = _dataParser.GetProductPrice();
        int quantity = _dataParser.GetProductQuantity();
        int discount = _dataParser.GetProductDiscount();

        _service.AddProduct(name, description, category, price, quantity, discount);

        Console.WriteLine("Товар добавлен");
    }

    private void AddCategory()
    {
        string categoryName = _dataParser.GetProductCategoryName();

        _service.AddProductCategory(categoryName);
        Console.WriteLine("Категория добавлена");
    }
    
    private void ProcessOrders()
    {
        List<Order> orders = _service.GetAllOrders();

        if (orders.Count == 0)
        {
            Console.WriteLine("Заказы отсутствуют");
            return;
        }
        
        foreach (Order order in orders)
        {
            List<OrderItem> orderItems = _service.GetOrderItemsByOrderId(order.Id);
            List<Product> products = _service.GetProductsByOrderId(order.Id);
            string address = _service
                .GetUserDeliveryDataByUserId(order.UserId)
                .Address;
            
            _postalController.SendPackage(order, orderItems, products, address);
        }
    }
}