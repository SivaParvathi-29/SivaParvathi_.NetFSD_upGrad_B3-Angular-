using CategoryService.Models;
using CategoryService.Repositories;

namespace CategoryService.Services
{
    public class CategoryServiceLogic
    {
        private readonly CategoryRepository _repository;

        public CategoryServiceLogic(CategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Category>> GetAllAsync()
            => await _repository.GetAllAsync();

        public async Task<Category> GetByIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        public async Task AddAsync(Category category)
            => await _repository.AddAsync(category);

        public async Task UpdateAsync(Category category)
            => await _repository.UpdateAsync(category);

        public async Task DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}