using System.ComponentModel.DataAnnotations;

namespace Build_Your_Meal.Models;

public class Ingredient
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    public int AmountAvailable { get; set; }

    public List<IngredientMeal>? IngredientMeals { get; set; } 
}
