using Microsoft.EntityFrameworkCore;

namespace Gachishop;

public class AdminService : IAdminService
{
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
        string name = AdminServiceDataParser.GetProductName();
        string description = AdminServiceDataParser.GetProductDescription();
        string category = AdminServiceDataParser.GetProductCategory();
        int price = AdminServiceDataParser.GetProductPrice();
        int quantity = AdminServiceDataParser.GetProductQuantity();
        int discount = AdminServiceDataParser.GetProductDiscount();

        using (ShopContext ctx = new ShopContext())
        {
            int categoryId = ctx.ProductCategories.First(c => c.Name == category).Id;
            ProductInventory inventory = new ProductInventory(quantity);
            ctx.ProductInventories.Add(inventory);
            ctx.SaveChanges();
            
            Product newProduct = new Product(name, description, price, discount, categoryId, inventory.Id);
            
            ctx.Products.Add(newProduct);
            ctx.SaveChanges();
        }
        
        Console.WriteLine("Товар добавлен. Нажмите любую клавишу");
        Console.ReadKey();
    }
}