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

    public void RemoveCartItemById(int id)
    {
        using (ShopContext ctx = new ShopContext())
        {
            CartItem cartItem = ctx.CartItems
                .First(i => i.Id == id);
            
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

    public void AddUserPayment(UserPayment userPayment)
    {
        using (ShopContext ctx = new ShopContext())
        {
            ctx.UserPayments.Add(userPayment);
            ctx.SaveChanges();
        }
    }

    public UserDeliveryData GetUserDeliveryDataByUserId(int id)
    {
        using (ShopContext ctx = new ShopContext())
        {
            return ctx.UserDeliveryData.
                FirstOrDefault(d => d.UserId == id);
        }
    }
    
    public void AddUserDeliveryData(UserDeliveryData userDeliveryData)
    {
        using (ShopContext ctx = new ShopContext())
        {
            ctx.UserDeliveryData.Add(userDeliveryData);
            ctx.SaveChanges();
        }
    }

    public int GetPriceOfAllCartProductsByCartId(int id)
    {
        using (ShopContext ctx = new ShopContext())
        {
            CartItem[] cartItems = GetCartItemsByCartId(id);
            int totalSum = 0;

            foreach (var cartItem in cartItems)
            {
                Product product = ctx.Products.First(p => p.Id == cartItem.ProductId);

                totalSum += product.Price * cartItem.Quantity;
            }

            return totalSum;
        }
    }

    public void AddOrder(Order order)
    {
        using (ShopContext ctx = new ShopContext())
        {
            ctx.Orders.Add(order);
            ctx.SaveChanges();
        }
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        using (ShopContext ctx = new ShopContext())
        {
            ctx.OrderItems.Add(orderItem);
            ctx.SaveChanges();
        }
    }

    public ProductInventory GetProductInventoryById(int id)
    {
        using (ShopContext ctx = new ShopContext())
        {
            return ctx.ProductInventories.First(i => i.Id == id);
        }
    }

    public void ReduceProductQuantityInInventory(int id, int quantity)
    {
        using (ShopContext ctx = new ShopContext())
        {
            ProductInventory productInventory = ctx.ProductInventories
                .First(i => i.Id == id);
            
            productInventory.Quantity -= quantity;
            ctx.SaveChanges();
        }
    }
}