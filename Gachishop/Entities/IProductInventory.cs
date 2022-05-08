using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class IProductInventory
{
    [Key] 
    int Id { get; set; }

    int Quantity { get; set; }
}