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

		if (ingredient == null)
			return BadRequest(ModelState);

		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		var exist = _repository.GetAllIngredients().Any(i => i.Name.Equals(ingredient.Name));

		if (exist)
		{
			ModelState.AddModelError("", "Ingredient already stored in the database");
			return BadRequest(ModelState);
		}


		var mapped = _mapper.Map<Ingredient>(ingredient);

		if (!_repository.CreateIngredient(mapped))
			return StatusCode(500, ModelState);
                
        return Ok("Created with success");
    }

	[HttpGet]
	public IActionResult GetAllIngredients()
	{
		var ingredients = _mapper.Map<List<IngredientDto>>(_repository.GetAllIngredients());

		return Ok(ingredients);
	}

	[HttpGet("{id}")]
	public IActionResult GetIngredient(int id)
	{
		if (!_repository.IngredientExist(id))
            return NotFound();

		var ingredient = _mapper.Map<IngredientDto>(_repository.GetIngredient(id));

		return Ok(ingredient);
	}

	//Query and Body "id" have to be the same
	[HttpPut("id")]
	public IActionResult UpdateIngredient(int id, [FromBody] IngredientDto ingredient)
	{
		if (ingredient == null)
			return BadRequest(ModelState);

		if(!ModelState.IsValid)
			return BadRequest();

		var exist = _repository.IngredientExist(id);


        if (!exist)
			return NotFound();

        var mapped = _mapper.Map<Ingredient>(ingredient);

		if (!_repository.UpdateIngredient(mapped))
			return StatusCode(500, ModelState);

		return Ok("Updated with success");
	}

	[HttpDelete("{id}")]
	public IActionResult DeleteIngredient(int id)
	{
        if (!_repository.IngredientExist(id))
            return NotFound();

		if (_repository.DeleteIngredient(id))
			return StatusCode(500, ModelState);

		return Ok("Deleted with success");
	}
}
