using AutoMapper;
using Build_Your_Meal.Dto;
using Build_Your_Meal.Interfaces;
using Build_Your_Meal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Build_Your_Meal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientController : Controller
{
	private readonly IIngredientRepository _repository;
	private readonly IMapper _mapper;

	public IngredientController(IIngredientRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	[HttpPost]
	public IActionResult CreateIngredient([FromBody] IngredientDto ingredient)
	{

		var mapped = _mapper.Map<Ingredient>(ingredient);

		if (_repository.CreateIngredient(mapped))
			return Ok("Created with success");

		return BadRequest(ModelState);
	}

	[HttpGet]
	public IActionResult GetAllIngredients()
	{
		var ingredients = _mapper.Map<List<IngredientDto>>( _repository.GetAllIngredients());

		return Ok(ingredients);
	}

	[HttpGet("{id}")]
	public IActionResult GetIngredient(int id)
	{
		var ingredient = _mapper.Map<IngredientDto>(_repository.GetIngredient(id));

		return Ok(ingredient);
	}

	[HttpPut]
	public IActionResult UpdateIngredient([FromBody] IngredientDto ingredient)
	{
		var mapped = _mapper.Map<Ingredient>(ingredient);

		_repository.UpdateIngredient(mapped);

		return Ok("Updated with success");
	}

	[HttpDelete("{id}")]
	public IActionResult DeleteIngredient(int id)
	{
		_repository.DeleteIngredient(id);
		return Ok("Deleted with success");
	}
}
