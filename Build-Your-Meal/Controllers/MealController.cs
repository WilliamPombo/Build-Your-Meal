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
        var mapped = _mapper.Map<Meal>(meal);

        _repository.CreateMeal(mapped);

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
        var mapped = _mapper.Map<MealDto>(_repository.GetMeal(id));
        return Ok(mapped);
    }

    [HttpDelete("id")]
    public IActionResult DeleteMeal(int id)
    {
        _repository.DeleteMeal(id);
        return Ok("Deleted with success");
    }

    [HttpPut]
    public IActionResult UpdateMeal([FromBody] MealDto meal)
    {
        var mapped = _mapper.Map<Meal>(meal);

        _repository.UpdateMeal(mapped);

        return Ok("Updated with success");
    }
}
