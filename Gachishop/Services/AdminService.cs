using Microsoft.EntityFrameworkCore;

namespace Gachishop;

public class AdminService : IAdminService
{
    public string[] GetProductCategories()
    {
        using (ShopContext ctx = new ShopContext())
        { 
            string[] productCategories = ctx.ProductCategories.Select(c => c.Name).ToArray();
            return productCategories;
        }
    }

    public void AddProduct(string name, string description, string category, int price, int quantity, int discount)
    {
        using (ShopContext ctx = new ShopContext())
        {
            int categoryId = ctx.ProductCategories
                .First(c => c.Name == category)
                .Id;
            ProductInventory inventory = new ProductInventory(quantity);
            ctx.ProductInventories.Add(inventory);
            ctx.SaveChanges();
            
            Product newProduct = new Product(name, description, price, discount, categoryId, inventory.Id);
            
            ctx.Products.Add(newProduct);
            ctx.SaveChanges();
        }
    }
}