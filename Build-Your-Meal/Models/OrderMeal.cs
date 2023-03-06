namespace Build_Your_Meal.Models;

public class OrderMeal
{
    public int MealId { get; set; }
    public int OrderId { get; set; }
    public Meal Meal { get; set; }
    public Order Order { get; set; }
}
