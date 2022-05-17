namespace Gachishop;

public interface IBuyerControllerDataParser
{
    int GetProductId(User user);
    int GetProductQuantity(int productId);
    int GetProductIdForDelete(User user);
    string GetCardNumber();
    string GetValidity();
    int GetSecurityCode();
    string GetAddress();
    string GetPhoneNumber();
    string GetPromoCode();
}