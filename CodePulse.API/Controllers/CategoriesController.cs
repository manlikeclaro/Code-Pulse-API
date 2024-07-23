using System.Net;
using AutoMapper;
using CodePulse.API.Data;
using CodePulse.API.Models;
using CodePulse.API.Models.Dto.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private APIResponse _apiResponse;

    public CategoriesController(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    // GET: api/categories
    [HttpGet]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategories()
    {
        try
        {
            var categories = await _dbContext.Categories.ToListAsync();
            _apiResponse = new APIResponse(
                data: categories
            );
            return Ok(_apiResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve Categories");
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newCategory = _mapper.Map<Category>(categoryDto);
        // newCategory.Id = Guid.NewGuid();
        await _dbContext.Categories.AddAsync(newCategory);
        await _dbContext.SaveChangesAsync();

        _apiResponse = new APIResponse(
            statusCode: HttpStatusCode.Created,
            data: newCategory
        );
        return Ok(_apiResponse);
    }
}