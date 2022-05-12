namespace Gachishop;

public class BuyerService : IBuyerService
{
    public Product GetProductById(int id)
    {
        using (ShopContext ctx = new ShopContext())
        {
            return ctx.Products
                .FirstOrDefault(p => p.Id == id);
        }
    }

    public Cart GetCartByUserId(int id)
    {
        using (ShopContext ctx = new ShopContext())
        {
            return ctx.Carts
                .First(c => c.UserId == id);
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

    public Product[] GetAllProducts()
    {
        using (ShopContext ctx = new ShopContext())
        {
            return ctx.Products.ToArray();
        }
    }

    public string GetCategoryNameById(int id)
    {
        using (ShopContext ctx = new ShopContext())
        {
            return ctx.ProductCategories
                .First(c => c.Id == id)
                .Name;
        }
    }

    public void AddCartItem(CartItem cartItem)
    {
        using (ShopContext ctx = new ShopContext())
        {
            ctx.CartItems.Add(cartItem);
            ctx.SaveChanges();
        }
    }

    public CartItem[] GetCartItemsByCartId(int id)
    {
        using (ShopContext ctx = new ShopContext())
        {
            return ctx.CartItems
                .Select(i => i)
                .Where(i => i.CartId == id)
                .ToArray();
        }
    }

    public CartItem GetCartItemByCartIdAndProductId(int cartId, int productId)
    {
        using (ShopContext ctx = new ShopContext())
        {
            return ctx.CartItems
                .Select(i => i)
                .Where(i => i.CartId == cartId)
                .First(i => i.ProductId == productId);
        }
    }

    public void RemoveCartItem(CartItem cartItem)
    {
        using (ShopContext ctx = new ShopContext())
        {
            ctx.CartItems.Remove(cartItem);
            ctx.SaveChanges();
        }
    }

    public UserPayment GetUserPaymentByUserId(int id)
    {
        using (ShopContext ctx = new ShopContext())
        {
            return ctx.UserPayments
                .FirstOrDefault(p => p.UserId == id);
        }
    }
}