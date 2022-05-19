namespace Gachishop.Controllers;

public class PostalController
{
    public void SendPackage(Order order, List<OrderItem> orderItems, List<Product> products, User user, string address)
    {
        Console.WriteLine($"Package with id {order.Id} was sent to {address} \n" +
                          $"Recipient: {user.Name} {user.Surname}");
        
        foreach (Product product in products)
        {
            int quantity = orderItems
                .Find(i => i.ProductId == product.Id)
                .Quantity;
            
            Console.WriteLine($"Product Name: {product.Name} " +
                              $"| Quantity: {quantity}");
        }
        
        Console.WriteLine("==========");
    }
}