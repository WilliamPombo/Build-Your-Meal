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
        if(client == null) 
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var cpfExist = _repository.GetAllClients().Any(c => c.CPF.Equals(client.CPF));

        if (cpfExist) 
        {
            ModelState.AddModelError("", "Client already stored in the database");
            return BadRequest(ModelState);
        }
            
        var mapped = _mapper.Map<Client>(client);

        if (!_repository.CreateClient(mapped))
            return StatusCode(500, ModelState);

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
        if (!_repository.ClientExist(id))
            return NotFound();

        var client = _mapper.Map<ClientDto>(_repository.GetClient(id));

        return Ok(client);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteClient(int id)
    {
        if (!_repository.ClientExist(id))
            return NotFound();

        if (_repository.DeleteClient(id))
            return StatusCode(500, ModelState);

        return Ok("Deleted with Success");
    }


    //Query and Body "id" have to be the same
    [HttpPut("id")]
    public IActionResult UpdateClient(int id, [FromBody] ClientDto client)
    {
        if (client == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_repository.ClientExist(id))
            return NotFound();

        var mapped = _mapper.Map<Client>(client);

        if (!_repository.UpdateClient(mapped))
            return StatusCode(500, ModelState);

        return Ok("Updated with success");
    }
}
