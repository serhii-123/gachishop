namespace Gachishop;

public class BuyerService : IBuyerService
{
    public Product FindProductById(int id)
    {
        using (ShopContext ctx = new ShopContext())
        {
            return ctx.Products
                .FirstOrDefault(p => p.Id == id);
        }
    }

    public Cart FindCartByUserId(int id)
    {
        using (ShopContext ctx = new ShopContext())
        {
            return ctx.Carts.First(c => c.UserId == id);
        }
    }

    public int[] GetCartItemIdsByCartId(int id)
    {
        using (ShopContext ctx = new ShopContext())
        {
            return ctx.CartItems
                .Select(i => i)
                .Where(i => i.CartId == id)
                .Select(i => i.ProductId)
                .ToArray();
        }
    }

    public int GetProductUnitsQuantityByInventoryId(int id)
    {
        using (ShopContext ctx = new ShopContext())
        {
            return ctx.ProductInventories
                .First(i => i.Id == id)
                .Quantity;
        }
    }
}