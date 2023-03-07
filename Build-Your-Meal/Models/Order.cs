using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_Your_Meal.Models;

public class Order
{
    public int Id { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Bill { get; set; }

    public List<OrderMeal>? OrderMeals { get; set; }
}
