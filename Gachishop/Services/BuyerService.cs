
namespace Gachishop;

public class BuyerService : IBuyerService
{
    private IUser _buyer;

    public BuyerService(IUser buyer)
    {
        _buyer = buyer;
    }

    public void Start()
    {
        bool done = false;
        int enteredNumber;
        
        Console.WriteLine("Welcome to the club, buddy");
        Console.WriteLine("++++++++++");

        while (!done)
        {
            Console.WriteLine("Введите номер команды: \n(1)Показать товары \n(2)Добавить товар в корзину \n(3)Удалить товар из корзины \n(4)Выйти");
            
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
                case(4):
                    done = true;
                    Console.Clear();
                    break;
                default:
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
                string productCategory = ctx.ProductCategories.First(c => c.Id == product.CategoryId).Name;
                int productQuantity = ctx.ProductInventories.First(i => i.Id == product.InventoryId).Quantity;
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Description);
                Console.WriteLine($"Номер товара: {product.Id} | Категория: {productCategory} | Цена: {product.Price}$ | Кол-во: {productQuantity} | Cкидка: {product.Discount}%");
                Console.WriteLine("----------");
            }
        }
    }

    private void AddProductToCart()
    {
        int productId = BuyerServiceDataParser.GetProductId();
        int productQuantity = BuyerServiceDataParser.GetProductQuantity(productId);

        using (ShopContext ctx = new ShopContext())
        {
            
        }
    }
}