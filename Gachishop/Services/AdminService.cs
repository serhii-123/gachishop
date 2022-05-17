using Microsoft.EntityFrameworkCore;

namespace Gachishop;

public class AdminService : IAdminService
{
    private ShopContext _ctx;

    public AdminService(ShopContext ctx)
    {
        _ctx = ctx;
    }
    public string[] GetProductCategories()
    {
        string[] productCategories = _ctx.ProductCategories.Select(c => c.Name).ToArray();
        return productCategories;
    }

    public void AddProduct(string name, string description, string category, int price, int quantity, int discount)
    {
        int categoryId = _ctx.ProductCategories
            .First(c => c.Name == category)
            .Id;
        ProductInventory inventory = new ProductInventory(quantity);
        _ctx.ProductInventories.Add(inventory);
        _ctx.SaveChanges();
            
        Product newProduct = new Product(name, description, price, discount, categoryId, inventory.Id);
            
        _ctx.Products.Add(newProduct);
        _ctx.SaveChanges();
    }

    public void AddProductCategory(string name)
    {
        ProductCategory productCategory = new ProductCategory(name);
        _ctx.ProductCategories.Add(productCategory);
        _ctx.SaveChanges();
    }
}