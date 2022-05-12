using System.ComponentModel.DataAnnotations;

namespace Gachishop;

public class UserDeliveryData
{
    [Key] public int Id { get; set; }
    public int UserId { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

    public UserDeliveryData(int userId, string address, string phoneNumber)
    {
        UserId = userId;
        Address = address;
        PhoneNumber = phoneNumber;
    }
}