using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_Your_Meal.Models;

public class Discount
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string? Title { get; set; }
    public List<Meal> Meals { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public decimal Amount { get; set; }
    public List<ClientDiscount>? ClientDiscounts { get; set; }
}
