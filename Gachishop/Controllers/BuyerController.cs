namespace Gachishop.Controllers;

public class BuyerController
{
    private User _buyer;
    private IBuyerService _service;
    private IBuyerControllerDataParser _dataParser; 

    public BuyerController(User buyer, IBuyerService service, IBuyerControllerDataParser dataParser)
    {
        _buyer = buyer;
        _service = service;
        _dataParser = dataParser;
    }

    public void Start()
    {
        bool done = false;
        int enteredNumber;
        
        Console.WriteLine("Welcome to the club, buddy");
        Console.WriteLine("++++++++++");

        while (!done)
        {
            Console.WriteLine("Введите номер команды: \n" +
                              "(1)Показать товары \n" +
                              "(2)Добавить товар в корзину \n" +
                              "(3)Показать содержимое корзины \n" +
                              "(4)Удалить товар из корзины \n" +
                              "(5)Купить товар(-ы) \n" +
                              "(6)Выйти \n");
            
            enteredNumber = CustomInput.ReadNumber();

            switch (enteredNumber)
            {
                case(1):
                    Console.Clear();
                    ShowProducts();
                    Console.WriteLine("Нажмите любую кнопку");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(2):
                    Console.Clear();
                    AddProductToCart();
                    Console.WriteLine("Нажмите любую кнопку");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(3):
                    Console.Clear();
                    ShowProductsFromCart();
                    Console.WriteLine("Нажмите любую кнопку");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(4):
                    Console.Clear();
                    DeleteProductFromCart();
                    Console.WriteLine("Нажмите любую кнопку");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(5):
                    Console.Clear();
                    BuyProducts();
                    Console.WriteLine("Нажмите любую кнопку");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(6):
                    done = true;
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Нет команды с данной цифрой");
                    break;
            }
        }
    }

    private void ShowProducts()
    {
        List<Product> products = _service.GetAllProducts();
        
        foreach (Product product in products)
        {
            string productCategory = _service.GetCategoryNameById(product.CategoryId);
            int productQuantity = _service.GetProductUnitsQuantityByInventoryId(product.InventoryId);

            if (productQuantity != 0)
            {
                Console.WriteLine($"{product.Name} \n" +
                                  $"{product.Description} \n" +
                                  $"Номер товара: {product.Id} " +
                                  $"| Категория: {productCategory} " +
                                  $"| Цена: {product.Price}$ " +
                                  $"| Кол-во: {productQuantity} " +
                                  $"| Cкидка: {product.Discount}% \n" +
                                  "----------");    
            }
        }
    }

    private void AddProductToCart()
    {
        int productId = _dataParser.GetProductId(_buyer);
        int productQuantity = _dataParser.GetProductQuantity(productId);
        Cart cart = _service.GetCartByUserId(_buyer.Id);

        _service.AddCartItem(cart.Id, productId, productQuantity);

        Console.WriteLine("Товар добавлен в корзину");
    }

    private void ShowProductsFromCart()
    {
        Cart cart = _service.GetCartByUserId(_buyer.Id);
        List<CartItem> cartItems = _service.GetCartItemsByCartId(cart.Id);
        
        if (cartItems.Count == 0)
        {
            Console.WriteLine("Корзина пуста");
            return;
        }
        
        foreach (CartItem cartItem in cartItems)
        {
            Product product = _service.GetProductById(cartItem.ProductId);
            
            Console.WriteLine($"Имя: {product.Name} " +
                              $"| Номер: {product.Id} " +
                              $"| Цена: {product.Price}$ " +
                              $"| Кол-во: {cartItem.Quantity} \n" +
                              "----------");
        }
    }

    private void DeleteProductFromCart()
    {
        Cart cart = _service.GetCartByUserId(_buyer.Id);
        List<CartItem> cartItems = _service.GetCartItemsByCartId(cart.Id);

        if (cartItems.Count == 0)
        {
            Console.WriteLine("Корзина пустая, удалять нечего");
            return;
        }
                
        int productId = _dataParser.GetProductIdForDelete(_buyer);
        CartItem cartItem = _service.GetCartItemByCartIdAndProductId(cart.Id, productId);
            
        _service.RemoveCartItemById(cartItem.Id);
        Console.WriteLine("Товар удален из корзины");
    }

    private void BuyProducts()
    {
        Cart cart = _service.GetCartByUserId(_buyer.Id);
        List<CartItem> cartItems = _service.GetCartItemsByCartId(cart.Id);
        UserPayment userPayment = _service.GetUserPaymentByUserId(_buyer.Id);
        UserDeliveryData userDeliveryData = _service.GetUserDeliveryDataByUserId(_buyer.Id);
        
        if (cartItems.Count == 0)
        {
            Console.WriteLine("Корзина пустая");
            return;
        }

        string promoCode = _dataParser.GetPromoCode();
        
        if (userPayment == null)
            CreateUserPayment();
       
        if (userDeliveryData == null)
            CreateDeliveryData();
        
        _service.CreateOrder(_buyer.Id, promoCode);

        Console.WriteLine("Ваш заказ принят");
    }

    public void CreateUserPayment()
    {
        string cardNumber = _dataParser.GetCardNumber();
        string validity = _dataParser.GetValidity();
        int securityCode = _dataParser.GetSecurityCode();
        
        _service.AddUserPayment(_buyer.Id, cardNumber, validity, securityCode);
    }

    public void CreateDeliveryData()
    {
        string address = _dataParser.GetAddress();
        string phoneNumber = _dataParser.GetPhoneNumber();
        
        _service.AddUserDeliveryData(_buyer.Id, address, phoneNumber);
    }
}