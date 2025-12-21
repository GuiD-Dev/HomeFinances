using GastosResidenciais.WebApi.API.DTOs;
using GastosResidenciais.WebApi.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GastosResidenciais.WebApi.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController(IPersonService personService) : ControllerBase
{
    [HttpGet]
    public IActionResult ListPeople()
    {
        return Ok(personService.ListPeople());
    }

    [HttpPost]
    public IActionResult InsertPerson(PersonDto dto)
    {
        return Created(string.Empty, personService.InsertPerson(dto));
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePerson(int id)
    {
        try
        {
            personService.DeletePerson(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
