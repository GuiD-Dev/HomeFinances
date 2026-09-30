using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinances.WebApi.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController(IPersonService personService) : ControllerBase
{
    [HttpGet("list")]
    public async Task<IActionResult> ListPeopleAsync()
    {
        return Ok(await personService.ListPeopleAsync());
    }

    /*
        Retorna as pessoas com suas transações associadas.
        A consulta é condicionada para retornar pessoas com suas transações,
        realizando um include ao executar a query no EF Core.
        Essa rota é a utilizada na funcionalidade de consulta de totais por pessoa.
    */
    [HttpGet("list-with-transactions")]
    public async Task<IActionResult> ListPeopleWithTransactionsAsync()
    {
        return Ok(await personService.ListPeopleWithTransactionsAsync());
    }

    [HttpPost]
    public async Task<IActionResult> InsertPersonAsync(PersonDto dto)
    {
        try
        {
            return Created(string.Empty, await personService.InsertPersonAsync(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePersonAsync(PersonDto dto)
    {
        try
        {
            await personService.UpdatePersonAsync(dto);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersonAsync(int id)
    {
        try
        {
            await personService.DeletePersonAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
