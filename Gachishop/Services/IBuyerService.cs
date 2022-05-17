namespace Gachishop;

public interface IBuyerService
{
    Product GetProductById(int id);
    Cart GetCartByUserId(int id);
    int[] GetCartItemIdsByCartId(int id);
    int GetProductUnitsQuantityByInventoryId(int id);
    Product[] GetAllProducts();
    string GetCategoryNameById(int id);
    void AddCartItem(int cartId, int productId, int productQuantity);
    CartItem[] GetCartItemsByCartId(int id);
    CartItem GetCartItemByCartIdAndProductId(int cartId, int productId);
    void RemoveCartItemById(int id);
    UserPayment GetUserPaymentByUserId(int id);
    void AddUserPayment(int userId, string cardNumber, string validity, int securityCode);
    UserDeliveryData GetUserDeliveryDataByUserId(int id);
    void AddUserDeliveryData(int userId, string address, string phoneNumber);
    int GetPriceOfAllCartProductsByCartId(int id);
    void AddOrder(int userId, int totalSum);
    void AddOrderItem(OrderItem orderItem);
    ProductInventory GetProductInventoryById(int id);
    void ReduceProductQuantityInInventory(int id, int quantity);
    void CreateOrder(int userId, string сode);
    PromoCode GetPromoCodeByCode(string code);
}