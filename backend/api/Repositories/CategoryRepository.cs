using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public CategoryRepository(ApplicationDBContext dbContext)
        {
            _dBContext = dbContext;
        }
        public async Task AddAsync(Category category)
        {
            await _dBContext.Category.AddAsync(category);
            await _dBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Category category)
        {
            _dBContext.Category.Remove(category);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dBContext.Category.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _dBContext.Category.FirstOrDefaultAsync(category => category.Id == id);
        }
    }
}