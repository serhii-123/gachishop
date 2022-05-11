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
            Console.WriteLine("Введите номер команды: " +
                              "\n(1)Показать товары " +
                              "\n(2)Добавить товар в корзину " +
                              "\n(3)Показать содержимое корзины " +
                              "\n(4)Удалить товар из корзины " +
                              "\n(5)Выйти");
            
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
        using (ShopContext ctx = new ShopContext())
        {
            IEnumerable<Product> list = ctx.Products.ToList();

            foreach (Product product in list)
            {
                string productCategory = ctx.ProductCategories
                    .First(c => c.Id == product.CategoryId)
                    .Name;
                int productQuantity = ctx.ProductInventories
                    .First(i => i.Id == product.InventoryId)
                    .Quantity;
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Description);
                Console.WriteLine($"Номер товара: {product.Id} " +
                                  $"| Категория: {productCategory} " +
                                  $"| Цена: {product.Price}$ " +
                                  $"| Кол-во: {productQuantity} " +
                                  $"| Cкидка: {product.Discount}%");
                Console.WriteLine("----------");
            }
        }
    }

    private void AddProductToCart()
    {
        int productId = _dataParser.GetProductId(_buyer);
        int productQuantity = _dataParser.GetProductQuantity(productId);

        using (ShopContext ctx = new ShopContext())
        {
            Cart cart = ctx.Carts.First(c => c.UserId == _buyer.Id);
            CartItem cartItem = new CartItem(cart.Id, productId, productQuantity);
            
            ctx.CartItems.Add(cartItem);
            ctx.SaveChanges();
        }
        
        Console.WriteLine("Товар добавлен в корзину");
    }

    private void ShowProductsFromCart()
    {
        using (ShopContext ctx = new ShopContext())
        {
            Cart cart = ctx.Carts.First(c => c.UserId == _buyer.Id);
            CartItem[] cartItems = ctx.CartItems.Select(i => i).Where(i => i.CartId == cart.Id).ToArray();

            if (cartItems.Length == 0)
            {
                Console.WriteLine("Корзина пуста");
                return;
            }

            foreach (CartItem cartItem in cartItems)
            {
                Product product = ctx.Products.First(p => p.Id == cartItem.ProductId);
                Console.WriteLine($"Имя: {product.Name} " +
                                  $"| Номер: {product.Id} " +
                                  $"| Цена: {product.Price}$ " +
                                  $"| Кол-во: {cartItem.Quantity}");
                Console.WriteLine("----------");
            }
        }
    }

    private void DeleteProductFromCart()
    {
        int productId = _dataParser.GetProductIdForDelete(_buyer);

        using (ShopContext ctx = new ShopContext())
        {
            Cart cart = ctx.Carts.
                First(c => c.UserId == _buyer.Id);
            CartItem cartItem = ctx.CartItems
                .Select(i => i)
                .Where(i => i.CartId == cart.Id)
                .First(i => i.ProductId == productId);
            ctx.CartItems.Remove(cartItem);
            ctx.SaveChanges();
        }
        
        Console.WriteLine("Товар удален из корзины");
    }
}