using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinances.WebApi.API.Controllers;

[Route("[controller]")]
[ApiController]
public class TransactionController(ITransactionService transactionService) : ControllerBase
{
    [HttpGet]
    public IActionResult LisTransactions()
    {
        return Ok(transactionService.ListTransactions());
    }

    [HttpPost]
    public IActionResult InsertTransaction(TransactionDto dto)
    {
        try
        {
            return Created(string.Empty, transactionService.InsertTransaction(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTransaction(int id)
    {
        try
        {
            transactionService.DeleteTransaction(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
