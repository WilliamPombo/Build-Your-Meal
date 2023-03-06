using AutoMapper;
using Build_Your_Meal.Dto;
using Build_Your_Meal.Interfaces;
using Build_Your_Meal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Build_Your_Meal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountController : Controller
{
    private readonly IDiscountRepository _repository;
    private readonly IMapper _mapper;

    public DiscountController(IDiscountRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateDiscount([FromBody] DiscountDto discount)
    {
        var mapped = _mapper.Map<Discount>(discount);

        _repository.CreateDiscount(mapped);

        return Ok("Created with Success");
    }

    [HttpGet]
    public IActionResult GetAllDiscounts()
    {
        var discounts = _mapper.Map<List<DiscountDto>>(_repository.GetAllDiscounts());
        return Ok(discounts);
    }

    [HttpGet("{id}")]
    public IActionResult GetDiscount(int id)
    {
        var discount = _mapper.Map<DiscountDto>(_repository.GetDiscount(id));
        return Ok(discount);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDiscount(int id)
    {
        _repository.DeleteDiscount(id);
        return Ok("Deleted with Success");
    }

    [HttpPut]
    public IActionResult UpdateDiscount([FromBody] DiscountDto discount)
    {
        var mapped = _mapper.Map<Discount>(discount);

        _repository.UpdateDiscount(mapped);

        return Ok("Updated with success");
    }
}
