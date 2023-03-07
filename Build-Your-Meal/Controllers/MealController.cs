using AutoMapper;
using Build_Your_Meal.Dto;
using Build_Your_Meal.Interfaces;
using Build_Your_Meal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Build_Your_Meal.Controllers;


[Route("[controller]")]
[ApiController]
public class MealController : Controller
{
    private readonly IMealRepository _repository;
    private readonly IMapper _mapper;

    public MealController(IMealRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateMeal([FromBody] MealDto meal)
    {

        if (meal == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool exist = _repository.GetAllMeals().Any(m => m.Name.Equals(meal.Name));

        if (exist) 
        {
            ModelState.AddModelError("", "This meal already exists");
            return BadRequest(ModelState);
        }

        var mapped = _mapper.Map<Meal>(meal);

        if (!_repository.CreateMeal(mapped))
        {
            ModelState.AddModelError("", "Error while saving");
            return StatusCode(500, ModelState);
        }

        return Ok("Created with success");
    }

    [HttpGet]
    public IActionResult GetAllMeals()
    {
        var mapped = _mapper.Map<List<MealDto>>(_repository.GetAllMeals());
        return Ok(mapped);
    }

    [HttpGet("{id}")]
    public IActionResult GetMeal(int id)
    {
        if (!_repository.MealExist(id))
            return NotFound();

        var mapped = _mapper.Map<MealDto>(_repository.GetMeal(id));
        return Ok(mapped);
    }

    [HttpDelete("id")]
    public IActionResult DeleteMeal(int id)
    {
        if (!_repository.MealExist(id))
            NotFound();

        if (_repository.DeleteMeal(id))
            return StatusCode(500, ModelState);

        return Ok("Deleted with success");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMeal(int id , [FromBody] MealDto meal)
    {
        if (meal == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool exist = _repository.MealExist(id);

        if (!exist)
            return NotFound();

        var mapped = _mapper.Map<Meal>(meal);

        if (!_repository.UpdateMeal(mapped))
            return StatusCode(500, ModelState);

        return Ok("Updated with success");
    }
}
