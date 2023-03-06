namespace Build_Your_Meal.Models;

public class IngredientMeal
{
    public int MealId { get; set; }
    public int IngredientId { get; set; }
    public Meal Meal { get; set; }
    public Ingredient Ingredient { get; set; }

}
