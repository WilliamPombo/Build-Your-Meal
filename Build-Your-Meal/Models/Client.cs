using System.ComponentModel.DataAnnotations;

namespace Build_Your_Meal.Models;

public class Client
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string CPF { get; set; }

    public DateTime BirthDay { get; set; }

    public List<ClientDiscount>? ClientDiscounts { get; set; }
}
