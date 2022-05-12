namespace Gachishop;

public interface IBuyerService
{
    Product GetProductById(int id);
    Cart GetCartByUserId(int id);
    int[] GetCartItemIdsByCartId(int id);
    int GetProductUnitsQuantityByInventoryId(int id);
    Product[] GetAllProducts();
    string GetCategoryNameById(int id);
    void AddCartItem(CartItem cartItem);
    CartItem[] GetCartItemsByCartId(int id);
    CartItem GetCartItemByCartIdAndProductId(int cartId, int productId);
    void RemoveCartItem(CartItem cartItem);
    UserPayment GetUserPaymentByUserId(int id);
    void AddUserPayment(UserPayment userPayment);
    UserDeliveryData GetUserDeliveryDataByUserId(int id);
    void AddUserDeliveryData(UserDeliveryData userDeliveryData);
}