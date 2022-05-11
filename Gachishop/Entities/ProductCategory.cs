using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class ProductCategory
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public ProductCategory(string name)
    {
        Name = name;
    }
}