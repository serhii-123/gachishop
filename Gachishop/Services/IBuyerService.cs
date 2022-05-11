namespace Gachishop;

public interface IBuyerService
{
    Product FindProductById(int id);
    Cart FindCartByUserId(int id);
    int[] GetCartItemIdsByCartId(int id);
}