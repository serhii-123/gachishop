namespace Gachishop;

public interface IAdminControllerDataParser
{
    string GetProductName();
    string GetProductDescription();
    string GetProductCategory();
    int GetProductPrice();
    int GetProductQuantity();
    int GetProductDiscount();
    string GetProductCategoryName();
}