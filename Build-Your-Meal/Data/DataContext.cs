using Build_Your_Meal.Models;
using Microsoft.EntityFrameworkCore;

namespace Build_Your_Meal.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
		
	}

	public DbSet<Client> Clients { get; set; }
	public DbSet<Discount> Discounts { get; set; }
	public DbSet<Ingredient> Ingredients { get; set;}
	public DbSet<Order> Orders { get;set; }
	public DbSet<Meal> Meals { get; set; }
	public DbSet<Menu> Menus { get; set; }
	public DbSet<IngredientMeal> IngredientMeals { get; set; }
	public DbSet<MenuMeal> MenuMeals { get; set; }
	public DbSet<OrderMeal> OrderMeals { get; set; }
	public DbSet<ClientDiscount> ClientDiscounts { get; set;  }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<IngredientMeal>()
			.HasKey(im => new { im.IngredientId, im.MealId });
		modelBuilder.Entity<IngredientMeal>()
			.HasOne(i => i.Ingredient)
			.WithMany(im => im.IngredientMeals);
		modelBuilder.Entity<IngredientMeal>()
			.HasOne(m => m.Meal)
			.WithMany(im => im.IngredientMeals);

		modelBuilder.Entity<ClientDiscount>()
			.HasKey(cd => new { cd.DiscountId, cd.ClientId });
		modelBuilder.Entity<ClientDiscount>()
			.HasOne(c => c.Client)
			.WithMany(cd => cd.ClientDiscounts);
		modelBuilder.Entity<ClientDiscount>()
			.HasOne(d => d.Discount)
			.WithMany(cd => cd.ClientDiscounts);

		modelBuilder.Entity<MenuMeal>()
			.HasKey(mm => new { mm.MenuId, mm.MealId });
		modelBuilder.Entity<MenuMeal>()
			.HasOne(m => m.Meal)
			.WithMany(mm => mm.MenuMeals);
		modelBuilder.Entity<MenuMeal>()
			.HasOne(m => m.Menu)
			.WithMany(mm => mm.MenuMeals);

		modelBuilder.Entity<OrderMeal>()
			.HasKey(om => new { om.MealId, om.OrderId });
		modelBuilder.Entity<OrderMeal>()
			.HasOne(o => o.Order)
			.WithMany(om => om.OrderMeals);
		modelBuilder.Entity<OrderMeal>()
			.HasOne(m => m.Meal)
			.WithMany(om => om.OrderMeals);

	}

}
