using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class ProductCategory : IProductCategory
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}