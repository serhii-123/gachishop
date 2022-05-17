namespace Gachishop;

public interface IAdminService
{
    string[] GetProductCategories();
    void AddProduct(string name, string description, string category, int price, int quantity, int discount);
    void AddProductCategory(string name);
    Order[] GetAllOrders();
    OrderItem[] GetOrderItemsByOrderId(int id);
    UserDeliveryData GetUserDeliveryDataByUserId(int id);
}