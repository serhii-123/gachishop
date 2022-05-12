using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace Gachishop;

public class BuyerControllerDataParser : IBuyerControllerDataParser
{
    private IBuyerService _service;

    public BuyerControllerDataParser(IBuyerService service)
    {
        _service = service;
    }
    public int GetProductId(User user)
    {
        int id;
        
        Console.WriteLine("Введите номер товара");
        id = CustomInput.ReadNumber();
        
        while (true)
        {
            Product product = _service.GetProductById(id);
            
            if (product == null)
            {
                Console.WriteLine("Ошибка! Нет товара с таким номером. Введите другой");
                id = CustomInput.ReadNumber();
                continue;
            }
            
            Cart cart = _service.GetCartByUserId(user.Id);
            int[] cartItems = _service.GetCartItemIdsByCartId(cart.Id);

            if (cartItems.Contains(id))
            {
                Console.WriteLine("Ошибка! Товар с таким номером уже есть в корзине. Введите другой");
                id = CustomInput.ReadNumber();
                continue;
            }
            
            int quantityOfProductUnits = _service.GetProductUnitsQuantityByInventoryId(product.InventoryId);

            if (quantityOfProductUnits == 0) 
            {
                Console.WriteLine("Ошибка! Данный товар сейчас не доступен. Введите другой номер");
                id = CustomInput.ReadNumber();
                continue;
            }
            
            return id;
        }
    }

    public int GetProductQuantity(int productId)
    {
        int quantity;
        Product product = _service.GetProductById(productId);
        int currentQuantity = _service.GetProductUnitsQuantityByInventoryId(product.InventoryId);
        
        Console.WriteLine("Введите кол-во товаров");
        quantity = CustomInput.ReadNumber();

        while (true)
        {
            if (quantity > currentQuantity)
            {
                Console.WriteLine("Ошибка! Недоступно такое количество. Введите другое");
                quantity = CustomInput.ReadNumber();
                continue;
            }
            
            return quantity;
        }
    }

    public int GetProductIdForDelete(User user)
    {
        int productId;
        Cart cart = _service.GetCartByUserId(user.Id);
        int[] productIds = _service.GetCartItemIdsByCartId(cart.Id);
        
        Console.WriteLine("Введите номер товара");
        productId = CustomInput.ReadNumber();
        
        while (true)
        {
            if (!productIds.Contains(productId))
            {
                Console.WriteLine("Ошибка! В корзине нет товара с таким номером");
                productId = CustomInput.ReadNumber();
                continue;
            }

            return productId;
        }
    }

    public string GetCardNumber()
    {
        string cardNumber;
        
        Console.WriteLine("Введите номер карты");
        cardNumber = CustomInput.ReadCardNumber();
        
        return cardNumber;
    }

    public string GetValidity()
    {
        string validity;
        string regexp = @"^(0[1-9]|1[0-2])\/?([0-9]{2})$";
        
        Console.WriteLine("Введите дату, до которой действительна карта");
        validity = CustomInput.ReadText();

        while (true)
        {
            if (!Regex.IsMatch(validity, regexp))
            {
                Console.WriteLine("Ошибка! Введенная строка не соответствует формату. Введите другую");
                validity = CustomInput.ReadText();
                continue;
            }

            return validity;
        }
    }

    public int GetSecurityCode()
    {
        int securityCode;
        
        Console.WriteLine("Введите защитный код");
        securityCode = CustomInput.ReadSecurityCode();

        return securityCode;
    }
}