using System.ComponentModel;

namespace Build_Your_Meal.Models;

public class ClientDiscount
{
    public int ClientId { get; set; }
    public int DiscountId { get; set; }
    public Client Client { get; set; }
    public Discount Discount { get; set; }
}
