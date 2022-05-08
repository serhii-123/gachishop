using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public interface IProductCategory
{
    [Key]
    int Id { get; set; }
    string Name { get; set; }
}