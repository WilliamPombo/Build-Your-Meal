using AutoMapper;
using Build_Your_Meal.Dto;
using Build_Your_Meal.Interfaces;
using Build_Your_Meal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Build_Your_Meal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : Controller
{
    private readonly IClientRepository _repository;
    private readonly IMapper _mapper;

    public ClientController(IClientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateClient([FromBody] ClientDto client)
    {
        var mapped = _mapper.Map<Client>(client);

        _repository.CreateClient(mapped);

        return Ok("Created with Success");
    }

    [HttpGet]
    public IActionResult GetAllClients()
    {
        var clients =  _mapper.Map<List<ClientDto>>(_repository.GetAllClients());
        return Ok(clients);
    }

    [HttpGet("{id}")]
    public IActionResult GetClient(int id)
    {
        var client = _mapper.Map<ClientDto>(_repository.GetClient(id));
        return Ok(client);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteClient(int id)
    {
        _repository.DeleteClient(id);
        return Ok("Deleted with Success");
    }

    [HttpPut]
    public IActionResult UpdateClient([FromBody] ClientDto client)
    {
        var mapped = _mapper.Map<Client>(client);

        _repository.UpdateClient(mapped);

        return Ok("Updated with success");
    }
}
