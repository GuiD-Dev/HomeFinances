using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinances.WebApi.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ListCategoriesAsync()
    {
        return Ok(await categoryService.ListCategoriesAsync());
    }

    [HttpPost]
    public async Task<IActionResult> InsertCategoryAsync(CategoryDto dto)
    {
        try
        {
            return Created(string.Empty, await categoryService.InsertCategoryAsync(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryAsync(int id)
    {
        try
        {
            await categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
