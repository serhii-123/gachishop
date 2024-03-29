namespace Gachishop;

public class BuyerService : IBuyerService
{
    private ShopContext _ctx;

    public BuyerService(ShopContext ctx)
    {
        _ctx = ctx;
    }
    public Product GetProductById(int id)
    {
        return _ctx.Products
            .FirstOrDefault(p => p.Id == id);
    }

    public Cart GetCartByUserId(int id)
    {
        return _ctx.Carts
            .First(c => c.UserId == id);
    }

    public List<int> GetCartItemIdsByCartId(int id)
    {
        return _ctx.CartItems
            .Select(i => i)
            .Where(i => i.CartId == id)
            .Select(i => i.ProductId)
            .ToList();
    }

    public int GetProductUnitsQuantityByInventoryId(int id)
    {
        return _ctx.ProductInventories
            .First(i => i.Id == id)
            .Quantity;
    }

    public List<Product> GetAllProducts()
    {
        return _ctx.Products.ToList();
    }

    public string GetCategoryNameById(int id)
    {
        return _ctx.ProductCategories
                .First(c => c.Id == id)
                .Name;
    }

    public void AddCartItem(int cartId, int productId, int productQuantity)
    {
        CartItem cartItem = new CartItem(cartId, productId, productQuantity);
        
        _ctx.CartItems.Add(cartItem); 
        _ctx.SaveChanges();
    }

    public List<CartItem> GetCartItemsByCartId(int id)
    {
        return _ctx.CartItems
            .Select(i => i)
            .Where(i => i.CartId == id)
            .ToList();
    }

    public CartItem GetCartItemByCartIdAndProductId(int cartId, int productId)
    {
        return _ctx.CartItems
            .Select(i => i)
            .Where(i => i.CartId == cartId)
            .First(i => i.ProductId == productId);
    }

    public void RemoveCartItemById(int id)
    {
        CartItem cartItem = _ctx.CartItems
            .First(i => i.Id == id);
            
        _ctx.CartItems.Remove(cartItem);
        _ctx.SaveChanges();
    }

    public UserPayment GetUserPaymentByUserId(int id)
    {
        return _ctx.UserPayments
            .FirstOrDefault(p => p.UserId == id);
    }

    public void AddUserPayment(int userId, string cardNumber, string validity, int securityCode)
    {
        UserPayment userPayment = new UserPayment(userId, cardNumber, validity, securityCode);
        
        _ctx.UserPayments.Add(userPayment);
        _ctx.SaveChanges();
    }

    public UserDeliveryData GetUserDeliveryDataByUserId(int id)
    {
        return _ctx.UserDeliveryData.
            FirstOrDefault(d => d.UserId == id);
    }
    
    public void AddUserDeliveryData(int userId, string address, string phoneNumber)
    {
        UserDeliveryData userDeliveryData = new UserDeliveryData(userId, address, phoneNumber);
        
        _ctx.UserDeliveryData.Add(userDeliveryData);
        _ctx.SaveChanges();
    }

    public int GetPriceOfAllCartProductsByCartId(int id)
    {
        List<CartItem> cartItems = GetCartItemsByCartId(id);
        int totalSum = 0;

        foreach (var cartItem in cartItems)
        {
            Product product = _ctx.Products.First(p => p.Id == cartItem.ProductId);

            totalSum += (product.Price - (product.Price / 100 * product.Discount)) * cartItem.Quantity;
        }

        return totalSum;
    }

    public void AddOrder(int userId, int totalSum)
    {
        Order order = new Order(userId, totalSum);
        
        _ctx.Orders.Add(order);
        _ctx.SaveChanges();
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        _ctx.OrderItems.Add(orderItem);
        _ctx.SaveChanges();
    }

    public ProductInventory GetProductInventoryById(int id)
    {
        return _ctx.ProductInventories.First(i => i.Id == id);
    }

    public void ReduceProductQuantityInInventory(int id, int quantity)
    {
        ProductInventory productInventory = _ctx.ProductInventories
            .First(i => i.Id == id);
            
        productInventory.Quantity -= quantity;
        _ctx.SaveChanges();
    }

    public PromoCode GetPromoCodeByCode(string code)
    {
        return _ctx.PromoCodes
            .FirstOrDefault(c => c.Code == code);
    }

    public void CreateOrder(int userId, string сode)
    {
        User user = GetUserById(userId);
        Cart cart = GetCartByUserId(userId);
        List<CartItem> cartItems = GetCartItemsByCartId(cart.Id);
        int priceOfProducts = GetPriceOfAllCartProductsByCartId(cart.Id);
        int totalPrice = priceOfProducts - (priceOfProducts / 100 * user.Discount);

        if (сode != "")
        {
            PromoCode promoCode = GetPromoCodeByCode(сode);
            totalPrice -= (totalPrice / 100 * promoCode.Discount);
        }
            
        Order order = new Order(userId, totalPrice);
        
        _ctx.Orders.Add(order);
        _ctx.SaveChanges();
        
        foreach (CartItem cartItem in cartItems)
        {
            OrderItem orderItem = new OrderItem(order.Id, cartItem.ProductId, cartItem.Quantity);
            Product product = GetProductById(cartItem.ProductId);
            ProductInventory productInventory = GetProductInventoryById(product.InventoryId);

            AddOrderItem(orderItem);
            RemoveCartItemById(cartItem.Id);
            ReduceProductQuantityInInventory(productInventory.Id, cartItem.Quantity);
        }
    }

    public int GetTotalPriceOfLastOrderByUserId(int id)
    {
        List<Order> orders = _ctx.Orders
            .Select(o => o)
            .Where(o => o.UserId == id)
            .ToList();
        
        return orders.Last().Total;
    }

    public User GetUserById(int id)
    {
        return _ctx.Users.First(u => u.Id == id);
    }
}