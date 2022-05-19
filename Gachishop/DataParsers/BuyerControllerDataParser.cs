using System.Text.RegularExpressions;

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
        
        Console.WriteLine("Enter product id");
        id = CustomInput.ReadNumber();
        
        while (true)
        {
            Product product = _service.GetProductById(id);
            
            if (product == null)
            {
                Console.WriteLine("Error! There is no product with this id. Try again");
                id = CustomInput.ReadNumber();
                continue;
            }
            
            Cart cart = _service.GetCartByUserId(user.Id);
            List<int> cartItemIds = _service.GetCartItemIdsByCartId(cart.Id);

            if (cartItemIds.Contains(id))
            {
                Console.WriteLine("Error! Product with this number is already in the cart. Try again");
                id = CustomInput.ReadNumber();
                continue;
            }
            
            int quantityOfProductUnits = _service.GetProductUnitsQuantityByInventoryId(product.InventoryId);

            if (quantityOfProductUnits == 0) 
            {
                Console.WriteLine("Error! This product is currently not available. Try again");
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
        
        Console.WriteLine("Enter product quantity that you want");
        quantity = CustomInput.ReadNumber();

        while (true)
        {
            if (quantity > currentQuantity)
            {
                Console.WriteLine("Error! This amount is not available. Try again");
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
        List<int> productIds = _service.GetCartItemIdsByCartId(cart.Id);
        
        Console.WriteLine("Enter product id");
        productId = CustomInput.ReadNumber();
        
        while (true)
        {
            if (!productIds.Contains(productId))
            {
                Console.WriteLine("Error! There is no product with this id in the cart");
                productId = CustomInput.ReadNumber();
                continue;
            }

            return productId;
        }
    }

    public string GetCardNumber()
    {
        string cardNumber;
        
        Console.WriteLine("Enter card numbers");
        cardNumber = CustomInput.ReadCardNumber();
        
        return cardNumber;
    }

    public string GetValidity()
    {
        string validity;

        Console.WriteLine("Enter the date until which the card is valid");
        validity = CustomInput.ReadValidity();

        return validity;
    }

    public int GetSecurityCode()
    {
        int securityCode;
        
        Console.WriteLine("Enter CVV code");
        securityCode = CustomInput.ReadSecurityCode();

        return securityCode;
    }

    public string GetAddress()
    {
        string address;
        
        Console.WriteLine("Enter shipping address");
        address = CustomInput.ReadText();

        while (true)
        {
            if (address.Length < 15)
            {
                Console.WriteLine("Error! Too short string was entered. Try again");
                address = CustomInput.ReadText();
                continue;
            }

            return address;
        }
    }

    public string GetPhoneNumber()
    {
        string phoneNumber;
        
        Console.WriteLine("Enter phone number");
        phoneNumber = CustomInput.ReadPhoneNumber();

        return phoneNumber;
    }

    public string GetPromoCode()
    {
        string answer;

        Console.WriteLine("Would you like to enter a promo code? \n" +
                          "(Enter \"yes\" or \"no\")");
        answer = CustomInput.ReadYesOrNo();

        if (answer == "no")
            return "";
        
        string promoCode;
        Console.WriteLine("Enter promo code");
        promoCode = CustomInput.ReadText();

        while (true)
        {
            if (_service.GetPromoCodeByCode(promoCode) == null)
            {
                Console.WriteLine("Error! This promo code does not exist. try again");
                promoCode = CustomInput.ReadText();
                continue;
            }

            return promoCode;
        }
    }
}