using System.Net;
using AutoMapper;
using CodePulse.API.Models;
using CodePulse.API.Models.Dto.Category;
using CodePulse.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        // Dependencies for data access and object mapping
        private readonly IRepository<Category> _dbContext;
        private readonly IMapper _mapper;

        // Constructor to inject the dependencies
        public CategoriesController(IRepository<Category> dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // GET: api/categories - Retrieve all categories
        [HttpGet]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                // Fetch all categories from the database
                var categories = await _dbContext.GetAllAsync();

                // Map the list of Category entities to a list of CategoryDto
                var mappedCategories = _mapper.Map<List<CategoryDto>>(categories);

                // Return OK status with the mapped categories in the API response
                return Ok(new APIResponse(data: mappedCategories));
            }
            catch (Exception)
            {
                // Handle any errors that occur during the process
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve categories");
            }
        }

        // GET: api/categories/{id} - Retrieve a single category by ID
        [HttpGet("{id:guid}", Name = "GetCategory")]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            // Validate the ID to ensure it is not empty or invalid
            if (id == Guid.Empty || id.GetType() != typeof(Guid))
                return BadRequest(new APIResponse(
                    statusCode: HttpStatusCode.BadRequest,
                    isSuccess: false, errorMessages: [$"Invalid ID '{id}'"]));

            try
            {
                // Fetch the category with the specified ID from the database
                var category = await _dbContext.GetAsync(obj => obj.Id == id);
                if (category == null)
                    return NotFound(new APIResponse(
                        statusCode: HttpStatusCode.NotFound, isSuccess: false,
                        errorMessages: [$"Category with ID '{id}' not found"]));

                // Map the Category entity to a Dto
                var mappedCategory = _mapper.Map<CategoryDto>(category);

                // Return OK status with the mapped category in the API response
                return Ok(new APIResponse(data: mappedCategory));
            }
            catch (Exception)
            {
                // Handle any errors that occur during the process
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new APIResponse(statusCode: HttpStatusCode.InternalServerError, isSuccess: false,
                        errorMessages: ["Failed to retrieve category"]));
            }
        }

        // PUT: api/categories/{id} - Update a category by ID
        [HttpPut("{id:guid}", Name = "UpdateCategory")]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            // Validate the ID to ensure it is not empty or invalid
            if (id == Guid.Empty || id.GetType() != typeof(Guid))
                return BadRequest(new APIResponse(
                    statusCode: HttpStatusCode.BadRequest, isSuccess: false,
                    errorMessages: [$"Invalid ID '{id}'"]));

            // Validate the incoming model state
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // Fetch the category with the specified ID from the database
                var category = await _dbContext.GetAsync(c => c.Id == id);
                if (category == null)
                    return NotFound(new APIResponse(statusCode: HttpStatusCode.NotFound, isSuccess: false,
                        errorMessages: [$"Category with ID '{id}' not found"]));

                // Map the updates from CategoryUpdateDto to the existing Category entity
                _mapper.Map(categoryUpdateDto, category);

                // Update the category in the database
                await _dbContext.UpdateAsync(category);

                // Map the updated Category entity to a CategoryDto
                var mappedCategory = _mapper.Map<CategoryDto>(category);

                // Return OK response with the updated category in the APIResponse
                return Ok(new APIResponse(data: mappedCategory));
            }
            catch (Exception)
            {
                // Handle any errors that occur during the process
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new APIResponse(statusCode: HttpStatusCode.InternalServerError, isSuccess: false,
                        errorMessages: ["Failed to update category"]));
            }
        }

        // POST: api/categories - Create a new category
        [HttpPost]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto categoryCreateDto)
        {
            // Validate the incoming model
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // Map the DTO to a new Category entity
                var newCategory = _mapper.Map<Category>(categoryCreateDto);

                // Create the new category in the database
                await _dbContext.CreateAsync(newCategory);

                // Return OK response with the created category in an APIResponse
                return Ok(new APIResponse(statusCode: HttpStatusCode.Created, data: newCategory));
            }
            catch (Exception)
            {
                // Handle any errors that occur during the process
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new APIResponse(statusCode: HttpStatusCode.InternalServerError, isSuccess: false,
                        errorMessages: ["Failed to create category"]));
            }
        }

        // DEL: api/categories/{id} - Delete a category by ID
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            // Validate the ID parameter
            if (id == Guid.Empty || id.GetType() != typeof(Guid))
                return BadRequest(new APIResponse(
                    statusCode: HttpStatusCode.BadRequest, isSuccess: false,
                    errorMessages: [$"Invalid ID '{id}'"]));

            try
            {
                // Fetch the category from the database using the provided ID
                var category = await _dbContext.GetAsync(c => c.Id == id);
                if (category == null)
                    return NotFound(new APIResponse(statusCode: HttpStatusCode.NotFound, isSuccess: false,
                        errorMessages: [$"Category with ID '{id}' not found"]));

                // Delete the category from the database
                await _dbContext.RemoveAsync(category);

                // Return 204 No Content response indicating successful deletion
                return NoContent();
            }
            catch (Exception)
            {
                // Handle any errors that occur during the process
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new APIResponse(statusCode: HttpStatusCode.InternalServerError, isSuccess: false,
                        errorMessages: ["Failed to delete category"]));
            }
        }
    }
}