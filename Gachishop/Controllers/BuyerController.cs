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
           
            Console.WriteLine("Enter operation number: \n" +
                              "(1)Show products \n" +
                              "(2)Add product to cart \n" +
                              "(3)Show cart content \n" +
                              "(4)Delete product from cart \n" +
                              "(5)Buy products \n" +
                              "(6)Exit \n");
            
            enteredNumber = CustomInput.ReadNumber();

            switch (enteredNumber)
            {
                case(1):
                    Console.Clear();
                    ShowProducts();
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(2):
                    Console.Clear();
                    AddProductToCart();
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(3):
                    Console.Clear();
                    ShowProductsFromCart();
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(4):
                    Console.Clear();
                    DeleteProductFromCart();
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(5):
                    Console.Clear();
                    BuyProducts();
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case(6):
                    done = true;
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Operation with this number does not exist");
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
                                  $"Product id: {product.Id} " +
                                  $"| Category: {productCategory} " +
                                  $"| Price: {product.Price}$ " +
                                  $"| Quantity: {productQuantity} " +
                                  $"| Discount: {product.Discount}% \n" +
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

        Console.WriteLine("Product added to cart");
    }

    private void ShowProductsFromCart()
    {
        Cart cart = _service.GetCartByUserId(_buyer.Id);
        List<CartItem> cartItems = _service.GetCartItemsByCartId(cart.Id);
        
        if (cartItems.Count == 0)
        {
            Console.WriteLine("Cart is empty");
            return;
        }
        
        foreach (CartItem cartItem in cartItems)
        {
            Product product = _service.GetProductById(cartItem.ProductId);
            
            Console.WriteLine($"Product name: {product.Name} " +
                              $"| Id: {product.Id} " +
                              $"| Price: {product.Price}$ " +
                              $"| Quantity: {cartItem.Quantity} \n" +
                              "----------");
        }
    }

    private void DeleteProductFromCart()
    {
        Cart cart = _service.GetCartByUserId(_buyer.Id);
        List<CartItem> cartItems = _service.GetCartItemsByCartId(cart.Id);

        if (cartItems.Count == 0)
        {
            Console.WriteLine("Cart is empty, nothing to delete");
            return;
        }
                
        int productId = _dataParser.GetProductIdForDelete(_buyer);
        CartItem cartItem = _service.GetCartItemByCartIdAndProductId(cart.Id, productId);
            
        _service.RemoveCartItemById(cartItem.Id);
        Console.WriteLine("Product deleted from cart");
    }

    private void BuyProducts()
    {
        Cart cart = _service.GetCartByUserId(_buyer.Id);
        List<CartItem> cartItems = _service.GetCartItemsByCartId(cart.Id);
        UserPayment userPayment = _service.GetUserPaymentByUserId(_buyer.Id);
        UserDeliveryData userDeliveryData = _service.GetUserDeliveryDataByUserId(_buyer.Id);
        
        if (cartItems.Count == 0)
        {
            Console.WriteLine("Cart is empty");
            return;
        }

        string promoCode = _dataParser.GetPromoCode();
        
        if (userPayment == null)
            CreateUserPayment();
       
        if (userDeliveryData == null)
            CreateUserDeliveryData();
        
        _service.CreateOrder(_buyer.Id, promoCode);
        int totalPrice = _service.GetTotalPriceOfLastOrderByUserId(_buyer.Id);
        
        Console.WriteLine($"Your order is accept. Order price: {totalPrice}$");
    }

    public void CreateUserPayment()
    {
        string cardNumber = _dataParser.GetCardNumber();
        string validity = _dataParser.GetValidity();
        int securityCode = _dataParser.GetSecurityCode();
        
        _service.AddUserPayment(_buyer.Id, cardNumber, validity, securityCode);
    }

    public void CreateUserDeliveryData()
    {
        string address = _dataParser.GetAddress();
        string phoneNumber = _dataParser.GetPhoneNumber();
        
        _service.AddUserDeliveryData(_buyer.Id, address, phoneNumber);
    }
}