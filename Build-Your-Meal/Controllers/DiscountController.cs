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
        if (discount == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool exist = _repository.GetAllDiscounts().Any(d => d.Title.Equals(discount.Title));

        if (exist)
        {
            ModelState.AddModelError("", "This discount already exists");
            return BadRequest(ModelState);
        }

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
        if (!_repository.DiscountExist(id))
            return NotFound();

        var discount = _mapper.Map<DiscountDto>(_repository.GetDiscount(id));
        return Ok(discount);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDiscount(int id)
    {
        if (!_repository.DiscountExist(id))
            return NotFound();

        if (_repository.DeleteDiscount(id))
            return StatusCode(500, ModelState);

        return Ok("Deleted with Success");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDiscount(int id, [FromBody] DiscountDto discount)
    {

        if (discount == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_repository.DiscountExist(id))
            return NotFound();

        var mapped = _mapper.Map<Discount>(discount);

        if (!_repository.UpdateDiscount(mapped)) 
            return StatusCode(500, ModelState);

        return Ok("Updated with success");
    }
}
