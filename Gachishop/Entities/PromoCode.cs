using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class PromoCode
{
    [Key]
    public int Id { get; set; }
    public string Code { get; set; }
    public int Discount { get; set; }
}