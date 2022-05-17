namespace Gachishop.Controllers;

public class PostalController
{
    public void SendPackage(Order order, string address)
    {
        Console.WriteLine($"Посылка с номером {order.Id} была отправлена по адресу {address}");
    }
}