using CodePulse.API.Data;
using CodePulse.API.Models;
using CodePulse.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Repository.Implementation
{
    public class CategoryRepository : IRepository<Category>
    {
        // Private readonly field to hold the database context
        private readonly ApplicationDbContext _dbContext;

        // Private field for the DbSet of Category entities
        private DbSet<Category> _dbSet;

        // Constructor to inject the database context
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Categories;
        }

        // Method to retrieve all categories asynchronously
        public async Task<List<Category>> GetAllAsync()
        {
            var categories = await _dbSet.ToListAsync();
            return categories;
        }

        // Method to retrieve a single category asynchronously (not implemented)
        public Task<Category> GetAsync()
        {
            throw new NotImplementedException();
        }

        // Method to create a new category asynchronously
        public async Task CreateAsync(Category entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        // Method to update an existing category asynchronously
        public async Task UpdateAsync(Category entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }

        // Method to remove a category asynchronously
        public async Task RemoveAsync(Category entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
        }

        // Method to save changes to the database asynchronously
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}