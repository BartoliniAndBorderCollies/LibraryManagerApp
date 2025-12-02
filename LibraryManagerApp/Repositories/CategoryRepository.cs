using LibraryManagerApp.Models;
using LibraryManagerApp.Models.EFCoreMapping;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApp.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {

        public readonly LibraryContext _libraryContext;

        public CategoryRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<Category> AddAsync(Category category)
        {
            await _libraryContext.Categories.AddAsync(category);
            await _libraryContext.SaveChangesAsync();

            return category;
        }

        public async Task DeleteAllAsync()
        {
            _libraryContext.Categories.RemoveRange(_libraryContext.Categories);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _libraryContext.Categories.Remove(category);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _libraryContext.Categories.ToListAsync();
        
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _libraryContext.Categories.FindAsync(id);
        }

        public async Task<Category?> UpdateAsync(int id, Category entity)
        {
            Category? category = await _libraryContext.Categories.FindAsync(id);

            if (category == null)
            {
                return null;

            }

            _libraryContext.Entry(category).CurrentValues.SetValues(entity);
            await _libraryContext.SaveChangesAsync();
            return category;
           
        }
    }
}
