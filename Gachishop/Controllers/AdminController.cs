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
            Console.WriteLine("Enter number of operation: \n" +
                               "(1)Add product \n" +
                               "(2)Add category \n" +
                               "(3)Process orders \n" +
                               "(4)Exit");
            enteredNumber = CustomInput.ReadNumber();

            switch (enteredNumber)
            {
                case(1):
                    Console.Clear();
                    AddProduct();
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(2):
                    Console.Clear();
                    AddCategory();
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(3):
                    Console.Clear();
                    ProcessOrders();
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(4):
                    done = true;
                    break;
                default:
                    Console.WriteLine("Operation with this number does not exist");
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

        Console.WriteLine("Product added");
    }

    private void AddCategory()
    {
        string categoryName = _dataParser.GetProductCategoryName();

        _service.AddProductCategory(categoryName);
        Console.WriteLine("Category added");
    }
    
    private void ProcessOrders()
    {
        List<Order> orders = _service.GetAllOrders();

        if (orders.Count == 0)
        {
            Console.WriteLine("No orders");
            return;
        }
        
        foreach (Order order in orders)
        {
            List<OrderItem> orderItems = _service.GetOrderItemsByOrderId(order.Id);
            List<Product> products = _service.GetProductsByOrderId(order.Id);
            User user = _service.GetUserById(order.UserId);
            string address = _service
                .GetUserDeliveryDataByUserId(order.UserId)
                .Address;
            
            _postalController.SendPackage(order, orderItems, products, user, address);
        }
        
        _service.RemoveAllOrderItems();
        _service.RemoveAllOrders();
    }
}