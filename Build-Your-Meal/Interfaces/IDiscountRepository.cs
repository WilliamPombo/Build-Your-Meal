using Build_Your_Meal.Models;

namespace Build_Your_Meal.Interfaces;

public interface IDiscountRepository
{
    List<Discount> GetAllDiscounts();
    Discount GetDiscount(int id);
    bool DiscountExist(int id);
    bool CreateDiscount(Discount discount);
    bool Save();
    bool DeleteDiscount(int id);
    bool UpdateDiscount(Discount discount);
}
