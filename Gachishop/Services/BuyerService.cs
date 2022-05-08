
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
            Console.WriteLine("Введите номер команды: \n(1)Показать товары \n(2)Выйти");
            
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
        int number = 0;
        
        using (ShopContext ctx = new ShopContext())
        {
            IEnumerable<Product> list = ctx.Products.ToList();

            foreach (Product product in list)
            {
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Description);
                Console.WriteLine($"Номер товара: {number} | Тип: {product.Type} | Цена: {product.Price}$ | Кол-во: {product.Quantity} | Cкидка: {product.Discount}%");
                Console.WriteLine("----------");
                number++;
            }
        }
    }
}