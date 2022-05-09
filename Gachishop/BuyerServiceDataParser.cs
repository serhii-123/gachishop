namespace Gachishop;

public static class BuyerServiceDataParser
{
    public static int GetProductId(User user)
    {
        int id;
        
        Console.WriteLine("Введите номер товара");
        id = CustomInput.ReadNumber();
        
        using (ShopContext ctx = new ShopContext())
        {
            while (true)
            {
                Product product = ctx.Products.FirstOrDefault(p => p.Id == id);
                
                if (product == null)
                {
                    Console.WriteLine("Ошибка! Нет товара с таким номером. Введите другой");
                    id = CustomInput.ReadNumber();
                    continue;
                }

                Cart cart = ctx.Carts.FirstOrDefault(c => c.UserId == user.Id);

                if (cart != null)
                {
                    int[] cartItems = ctx.CartItems.Select(i => i).Where(i => i.CartId == cart.Id).Select(i => i.Id).ToArray();

                    if (cartItems.Contains(id))
                    {
                        Console.WriteLine("Ошибка! Товар с таким номером уже есть в корзине. Введите другой");
                        id = CustomInput.ReadNumber();
                        continue;
                    }
                }
                
                bool quantityIsNotNull = ctx.ProductInventories.First(c => c.Id == product.CategoryId).Quantity > 0;

                if (!quantityIsNotNull)
                {
                    Console.WriteLine("Ошибка! Данный товар сейчас не доступен. Введите другой номер");
                    id = CustomInput.ReadNumber();
                    continue;
                }
                
                break;
            }
        }
        
        return id;
    }

    public static int GetProductQuantity(int productId)
    {
        int quantity, currentQuantity;
        Product product;

        using (ShopContext ctx = new ShopContext())
        {
            product = ctx.Products.First(p => p.Id == productId);
            currentQuantity = ctx.ProductInventories.First(i => i.Id == product.InventoryId).Quantity;
        }

        Console.WriteLine("Введите кол-во товаров");
        quantity = CustomInput.ReadNumber();

        while (true)
        {
            if (quantity > currentQuantity)
            {
                Console.WriteLine("Ошибка! Недоступно такое количество. Введите другое");
                quantity = CustomInput.ReadNumber();
            }
            else return quantity;
        }
    }
}