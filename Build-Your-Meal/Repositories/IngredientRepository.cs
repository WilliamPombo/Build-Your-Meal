using Build_Your_Meal.Data;
using Build_Your_Meal.Interfaces;
using Build_Your_Meal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Build_Your_Meal.Repositories;

public class IngredientRepository : IIngredientRepository
{
    private DataContext _context;

    public IngredientRepository(DataContext context)
    {
        _context = context;
    }

    public bool IngredientExist(int id)
    {
        return _context.Ingredients.Any(i => i.Id == id);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();

        return saved > 0 ? true : false;
    }

    public bool CreateIngredient(Ingredient ingredient)
    {
        //_context.Add(ingredient);
        _context.Ingredients.Add(ingredient);
        return Save();
    }

    public Ingredient GetIngredient(int id)
    {
        return _context.Ingredients.Where(i => i.Id == id).FirstOrDefault();
    }

    public List<Ingredient> GetAllIngredients()
    {
        return _context.Ingredients.ToList();
    }

    public bool DeleteIngredient(int id)
    {
        _context.Ingredients.Where(i => i.Id == id).ExecuteDelete();
        return Save();
    }

    public bool UpdateIngredient(Ingredient ingredient)
    {
        _context.Ingredients.Update(ingredient);
        return Save();
    }
}
