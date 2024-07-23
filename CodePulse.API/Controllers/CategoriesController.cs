﻿using System.Net;
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

                // Prepare API response with the fetched categories
                _apiResponse = new APIResponse(
                    data: categories
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