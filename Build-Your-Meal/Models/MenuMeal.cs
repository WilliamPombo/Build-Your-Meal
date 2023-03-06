namespace Build_Your_Meal.Models;

public class MenuMeal
{
    public int MenuId { get; set; }
    public int MealId { get; set; }
    public Menu Menu { get; set; }
    public Meal Meal { get; set;  }
}
