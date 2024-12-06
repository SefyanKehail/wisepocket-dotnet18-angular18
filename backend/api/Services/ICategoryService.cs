using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;

namespace api.Services
{
    public interface ICategoryService
    {
        Task AddAsync(CreateCategoryDTO createExpenseDTO);
        Task<CategoryDTO?> GetByIdAsync(int id);
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task DeleteAsync(int id);
        
    }
}