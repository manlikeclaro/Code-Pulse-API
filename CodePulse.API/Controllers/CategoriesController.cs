using System.Net;
using AutoMapper;
using CodePulse.API.Data;
using CodePulse.API.Models;
using CodePulse.API.Models.Dto.Category;
using CodePulse.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        // Private readonly fields to hold dependencies
        private readonly IRepository<Category> _dbContext;
        private readonly IMapper _mapper;
        private APIResponse _apiResponse;

        // Constructor to inject the dependencies
        public CategoriesController(IRepository<Category> dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // GET: api/categories - retrieve all categories
        [HttpGet]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                // Fetch all categories from the database
                var categories = await _dbContext.GetAllAsync();

                // Map the Category entity list to a Dto enumerable
                var mappedCategories = _mapper.Map<List<CategoryDto>>(categories);

                // Prepare API response with the fetched categories
                _apiResponse = new APIResponse(
                    data: mappedCategories
                );

                // Return OK status with the API response
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here) and return a 500 error response
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve categories");
            }
        }

        // GET: api/categories/{id} - retrieve single category
        [HttpGet("{id:guid}", Name = "GetCategory")]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            try
            {
                // Fetch single category from the database
                var category = await _dbContext.GetAsync(obj => obj.Id == id);

                if (category == null)
                {
                    _apiResponse = new APIResponse(
                        statusCode: HttpStatusCode.NotFound,
                        isSuccess: false,
                        errorMessages: [$"Category with id '{id}' does not exist!"]
                    );
                    return NotFound(_apiResponse);
                }

                // Map the Category entity to a Dto
                var mappedCategory = _mapper.Map<CategoryDto>(category);

                // Prepare API response with the fetched categories
                _apiResponse = new APIResponse(
                    data: mappedCategory
                );

                // Return OK status with the API response
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here) and return a 500 error response
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve categories");
            }
        }

        // POST: api/categories - create a new category
        [HttpPost]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            try
            {
                // Validate the incoming model
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Map the DTO to a Category entity
                var newCategory = _mapper.Map<Category>(categoryDto);

                // Create the new category in the database
                await _dbContext.CreateAsync(newCategory);

                // Prepare API response with the created category
                _apiResponse = new APIResponse(
                    statusCode: HttpStatusCode.Created,
                    data: newCategory
                );

                // Return OK status with the API response
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here) and return a 500 error response
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create category");
            }
        }
    }
}