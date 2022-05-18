using Microsoft.EntityFrameworkCore;

namespace Gachishop;

public class AdminService : IAdminService
{
    private ShopContext _ctx;

    public AdminService(ShopContext ctx)
    {
        _ctx = ctx;
    }
    public List<string> GetProductCategories()
    {
        List<string> productCategories = _ctx.ProductCategories.Select(c => c.Name).ToList();
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
        
        _ctx.ProductCategories
            .Add(productCategory);
        _ctx.SaveChanges();
    }

    public List<Order> GetAllOrders()
    {
        return _ctx.Orders
            .Select(o => o)
            .ToList();
    }

    public User GetUserById(int id)
    {
        return _ctx.Users.First(u => u.Id == id);
    }

    public List<OrderItem> GetOrderItemsByOrderId(int id)
    {
        return _ctx.OrderItems
            .Select(i => i)
            .Where(i => i.OrderId == id)
            .ToList();
    }

    public UserDeliveryData GetUserDeliveryDataByUserId(int id)
    {
        return _ctx.UserDeliveryData
            .First(d => d.UserId == id);
    }

    public Product GetProductById(int id)
    {
        return _ctx.Products.First(p => p.Id == id);
    }

    public List<Product> GetProductsByOrderId(int id)
    {
        List<OrderItem> orderItems = GetOrderItemsByOrderId(id);
        List<Product> products = new List<Product>();

        foreach (OrderItem orderItem in orderItems)
        {
            Product product = GetProductById(orderItem.ProductId);
            products.Add(product);
        }

        return products;
    }

    public void RemoveOrderItems(List<OrderItem> orderItems)
    {
        _ctx.OrderItems.RemoveRange(orderItems);
        _ctx.SaveChanges();
    }

    public void RemoveOrder(Order order)
    {
        _ctx.Orders.Remove(order);
        _ctx.SaveChanges();
    }
}