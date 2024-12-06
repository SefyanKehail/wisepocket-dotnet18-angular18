using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Exceptions;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task AddAsync(CreateCategoryDTO createCategoryDTO)
        {
            var category = new Category
            {
                Name = createCategoryDTO.Name,
                UserId = createCategoryDTO.UserId
            };

            await _categoryRepository.AddAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
            {
                throw new CategoryNotFoundException();
            }

            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(category => new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
            }
            );
        }

        public async Task<CategoryDTO?> GetByIdAsync(int id)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
            {
                throw new CategoryNotFoundException();
            }

            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
    }
}