namespace Gachishop;

public interface IAdminControllerDataParser
{
    string GetProductName();
    string GetProductDescription();
    string GetProductCategoryNameForProduct();
    int GetProductPrice();
    int GetProductQuantity();
    int GetProductDiscount();
    string GetProductCategoryName();
}