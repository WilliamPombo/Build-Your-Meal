using Build_Your_Meal.Data;
using Build_Your_Meal.Interfaces;
using Build_Your_Meal.Models;
using Microsoft.EntityFrameworkCore;

namespace Build_Your_Meal.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly DataContext _context;

    public DiscountRepository(DataContext context)
    {
        _context = context;
    }


    public bool DiscountExist(int id)
    {
        return _context.Discounts.Any(d => d.Id == id);
    }

    public bool CreateDiscount(Discount discount)
    {
        _context.Discounts.Add(discount);
        return Save();
    }

    public bool DeleteDiscount(int id)
    {
        _context.Discounts.Where(d => d.Id == id).ExecuteDelete();
        return Save();
    }

    public List<Discount> GetAllDiscounts()
    {
        return _context.Discounts.ToList();
    }

    public Discount GetDiscount(int id)
    {
        return _context.Discounts.Where(d => d.Id == id).FirstOrDefault();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool UpdateDiscount(Discount discount)
    {
        _context.Discounts.Update(discount);
        return Save();
    }
}
