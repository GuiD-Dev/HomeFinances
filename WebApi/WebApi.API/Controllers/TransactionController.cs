using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinances.WebApi.API.Controllers;

[Route("[controller]")]
[ApiController]
public class TransactionController(ITransactionService transactionService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> LisTransactionsAsync()
    {
        return Ok(await transactionService.ListTransactionsAsync());
    }

    [HttpPost]
    public async Task<IActionResult> InsertTransactionAsync(TransactionDto dto)
    {
        try
        {
            return Created(string.Empty, await transactionService.InsertTransactionAsync(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransactionAsync(int id)
    {
        try
        {
            await transactionService.DeleteTransactionAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
