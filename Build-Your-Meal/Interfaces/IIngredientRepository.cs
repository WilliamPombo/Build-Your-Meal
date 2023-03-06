using Build_Your_Meal.Models;

namespace Build_Your_Meal.Interfaces;

public interface IIngredientRepository
{
    List<Ingredient> GetAllIngredients();
    Ingredient GetIngredient(int id);
    bool IngredientExist(int id);
    bool CreateIngredient(Ingredient ingredient);
    bool Save();
    bool DeleteIngredient(int id);
    bool UpdateIngredient(Ingredient ingredient);
}
