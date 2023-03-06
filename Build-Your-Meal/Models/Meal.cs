using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_Your_Meal.Models;

public class Meal
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public decimal Price { get; set; }

    public List<IngredientMeal>? IngredientMeals { get; set; }
    public List<MenuMeal>? MenuMeals { get; set; }
    public List<OrderMeal>? OrderMeals { get; set;  }

    
}
