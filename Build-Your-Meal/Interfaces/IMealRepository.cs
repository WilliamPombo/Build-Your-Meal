using Build_Your_Meal.Models;

namespace Build_Your_Meal.Interfaces;

public interface IMealRepository
{
    bool Save();
    bool CreateMeal(Meal meal);
    bool UpdateMeal(Meal meal);
    bool DeleteMeal(int id);
    Meal GetMeal(int id);
    List<Meal> GetAllMeals();
    bool MealExist(int id);
}
