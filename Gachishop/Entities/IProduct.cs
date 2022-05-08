using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gachishop;

public interface IProduct
{
    [Key]
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    int Price { get; set; }
    int Discount { get; set; }
    int CategoryId { get; set; }
    int InventoryId { get; set; }
}