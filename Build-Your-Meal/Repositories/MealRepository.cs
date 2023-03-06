using Build_Your_Meal.Data;
using Build_Your_Meal.Interfaces;
using Build_Your_Meal.Models;
using Microsoft.EntityFrameworkCore;

namespace Build_Your_Meal.Repositories;

public class MealRepository : IMealRepository
{
    private readonly DataContext _context;

    public MealRepository(DataContext context)
    {
        _context = context;
    }

    public bool CreateMeal(Meal meal)
    {
        _context.Meals.Add(meal);
        return Save();
    }

    public bool DeleteMeal(int id)
    {
        _context.Meals.Where(m => m.Id == id).ExecuteDelete();

        return Save();
    }

    public List<Meal> GetAllMeals()
    {
        return _context.Meals.ToList();
    }

    public Meal GetMeal(int id)
    {
        return _context.Meals.Where(m => m.Id == id).FirstOrDefault();
    }

    public bool MealExist(int id)
    {
        return _context.Meals.Any(m => m.Id == id);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool UpdateMeal(Meal meal)
    {
        _context.Meals.Update(meal);
        return Save();
    }
}
