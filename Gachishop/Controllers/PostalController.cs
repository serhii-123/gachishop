namespace Gachishop.Controllers;

public class PostalController
{
    public void SendPackage(Order order, List<OrderItem> orderItems, List<Product> products, string address)
    {
        Console.WriteLine($"Посылка с номером {order.Id} была отправлена по адресу {address}");
        
        foreach (Product product in products)
        {
            int quantity = orderItems
                .Find(i => i.ProductId == product.Id)
                .Quantity;
            
            Console.WriteLine($"Название товара: {product.Name} " +
                              $"| Кол-во: {quantity}");
        }
        
        Console.WriteLine("==========");
    }
}