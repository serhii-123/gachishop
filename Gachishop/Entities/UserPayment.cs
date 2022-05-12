using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class UserPayment
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; } 
    public string Number { get; set; }
    public string Validity { get; set; }
    public int SecurityCode { get; set; }
}