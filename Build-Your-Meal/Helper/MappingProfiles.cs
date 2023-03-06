using AutoMapper;
using Build_Your_Meal.Dto;
using Build_Your_Meal.Models;

namespace Build_Your_Meal.Helper;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<IngredientDto, Ingredient> ();
		CreateMap<Ingredient, IngredientDto> ();
		CreateMap<Meal, MealDto> ();
		CreateMap<MealDto, Meal> ();
		CreateMap<Client, ClientDto>();
		CreateMap<ClientDto, Client>();
		CreateMap<DiscountDto, Discount> ();
		CreateMap<Discount, DiscountDto> ();
	}
}
