namespace Build_Your_Meal.Models;

public class Menu
{
    public int Id { get; set; }
    public List<MenuMeal>? MenuMeals { get; set; }
}
