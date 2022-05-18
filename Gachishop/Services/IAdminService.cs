namespace Gachishop;

public interface IAdminService
{
    List<string> GetProductCategories();
    void AddProduct(string name, string description, string category, int price, int quantity, int discount);
    void AddProductCategory(string name);
    List<Order> GetAllOrders();
    List<OrderItem> GetOrderItemsByOrderId(int id);
    UserDeliveryData GetUserDeliveryDataByUserId(int id);
    List<Product> GetProductsByOrderId(int id);
    void RemoveAllOrderItems();
    void RemoveAllOrders();
    User GetUserById(int id);
}