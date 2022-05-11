namespace Gachishop;

public interface IAdminService
{
    public string[] GetProductCategories();
    public void AddProduct(string name, string description, string category, int price, int quantity, int discount);
}