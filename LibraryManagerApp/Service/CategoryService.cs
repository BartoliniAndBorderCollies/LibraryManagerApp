using LibraryManagerApp.Exceptions;
using LibraryManagerApp.Models;
using LibraryManagerApp.Repositories;

namespace LibraryManagerApp.Service
{
    public class CategoryService
    {

        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<Category> AddAsync(Category entity)
        {
            return await _categoryRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {

            bool deleted = await _categoryRepository.DeleteAsync(id);

            if (!deleted)
            {
                throw new NotFoundInDatabaseException($"Category with id: {id} was not found");
            }

        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
           return await _categoryRepository.GetAllAsync();
        }

    }
}
