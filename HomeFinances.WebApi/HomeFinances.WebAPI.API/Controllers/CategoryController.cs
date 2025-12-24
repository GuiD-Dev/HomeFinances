using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinances.WebApi.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public IActionResult ListCategories()
    {
        return Ok(categoryService.ListCategories());
    }

    [HttpPost]
    public IActionResult InsertCategory(CategoryDto dto)
    {
        try
        {
            return Created(string.Empty, categoryService.InsertCategory(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        try
        {
            categoryService.DeleteCategory(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
