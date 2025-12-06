using LibraryManagerApp.Models;
using LibraryManagerApp.Repositories;

namespace LibraryManagerApp.Service
{
    public class AuthorService : IService<Author>
    {

        public readonly AuthorRepository authorRepository;

        public AuthorService(AuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }


        public Task<Author> AddAsync(Author entity)
        {
            return authorRepository.AddAsync(entity);
        }

        public Task DeleteAllAsync()
        {
            return authorRepository.DeleteAllAsync();
        }

        public Task DeleteAsync(Author entity)
        {
            return authorRepository.DeleteAsync(entity);
        }

        public Task<IEnumerable<Author>> GetAllAsync()
        {
            return authorRepository.GetAllAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {

            Author? author = await authorRepository.GetByIdAsync(id);

            if (author == null)
                throw new KeyNotFoundException($"Author with id: {id} - was not found");

            return author;
            
        }

        public async Task<Author> UpdateAsync(int id, Author entity)
        {
            Author? existingAuthor = await authorRepository.GetByIdAsync(id);

            if (existingAuthor == null)
                throw new KeyNotFoundException($"Author with id: {id} - was not found");

            Author? updated = await authorRepository.UpdateAsync(id, entity);

            if (updated == null)
                throw new InvalidOperationException("Failed to update the author!");

            return updated;
        }
    }
}
