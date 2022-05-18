namespace Gachishop.Controllers;

public class PostalController
{
    public void SendPackage(Order order, List<OrderItem> orderItems, List<Product> products, string address)
    {
        Console.WriteLine($"Посылка с номером {order.Id} была отправлена по адресу {address}");
    }
}