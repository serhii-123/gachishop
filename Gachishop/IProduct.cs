using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public interface IProduct
{
    [Key]
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string Type { get; set; }
    int Price { get; set; }
    int NumberOfUnits { get; set; }
    int Discount { get; set; }
}