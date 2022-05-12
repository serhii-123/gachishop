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
        Product[] products = _service.GetAllProducts();
        
        foreach (Product product in products)
        {
            string productCategory = _service.GetCategoryNameById(product.CategoryId);
            int productQuantity = _service.GetProductUnitsQuantityByInventoryId(product.InventoryId);
            
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

    private void AddProductToCart()
    {
        int productId = _dataParser.GetProductId(_buyer);
        int productQuantity = _dataParser.GetProductQuantity(productId);
        Cart cart = _service.GetCartByUserId(_buyer.Id);
        CartItem cartItem = new CartItem(cart.Id, productId, productQuantity);
        
        _service.AddCartItem(cartItem);

        Console.WriteLine("Товар добавлен в корзину");
    }

    private void ShowProductsFromCart()
    {
        Cart cart = _service.GetCartByUserId(_buyer.Id);
        CartItem[] cartItems = _service.GetCartItemsByCartId(cart.Id);
        
        if (cartItems.Length == 0)
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
                              $"----------");
        }
    }

    private void DeleteProductFromCart()
    {
        int productId = _dataParser.GetProductIdForDelete(_buyer);
        Cart cart = _service.GetCartByUserId(_buyer.Id);
        CartItem cartItem = _service.GetCartItemByCartIdAndProductId(cart.Id, productId);
            
        _service.RemoveCartItem(cartItem);
        Console.WriteLine("Товар удален из корзины");
    }

    private void BuyProducts()
    {
        Cart cart = _service.GetCartByUserId(_buyer.Id);
        CartItem[] cartItems = _service.GetCartItemsByCartId(cart.Id);

        if (cartItems.Length == 0)
        {
            Console.WriteLine("Корзина пустая, что ты покупать собрался, дубина?");
        }

        UserPayment userPayment = _service.GetUserPaymentByUserId(_buyer.Id);
        
        if (userPayment == null)
        {
            string cardNumber = _dataParser.GetCardNumber();
            string validity = _dataParser.GetValidity();
            int securityCode = _dataParser.GetSecurityCode();

            userPayment = new UserPayment(_buyer.Id, cardNumber, validity, securityCode);
            _service.AddUserPayment(userPayment);
        }

        UserDeliveryData userDeliveryData = _service.GetUserDeliveryDataByUserId(_buyer.Id);

        if (userDeliveryData == null)
        {
            string address = _dataParser.GetAddress();
            string phoneNumber = _dataParser.GetPhoneNumber();

            userDeliveryData = new UserDeliveryData(_buyer.Id, address, phoneNumber);
            _service.AddUserDeliveryData(userDeliveryData);
        }
        
        
    }
}