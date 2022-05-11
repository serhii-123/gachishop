namespace Gachishop;

public interface IAdminService
{
    string[] GetProductCategories();
    void AddProduct(string name, string description, string category, int price, int quantity, int discount);
    void AddProductCategory(ProductCategory productCategory);
}