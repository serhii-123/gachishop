namespace Gachishop;

public interface IBuyerService
{
    Product FindProductById(int id);
    Cart FindCartByUserId(int id);
    int[] GetCartItemIdsByCartId(int id);

    int GetProductUnitsQuantityByInventoryId(int id);
    Product[] GetAllProducts();
    string GetCategoryNameById(int id);
    void AddCartItem(CartItem cartItem);
    CartItem[] GetCartItemsByCartId(int id);
    CartItem GetCartItemByCartIdAndProductId(int cartId, int productId);
    void RemoveCartItem(CartItem cartItem);
}