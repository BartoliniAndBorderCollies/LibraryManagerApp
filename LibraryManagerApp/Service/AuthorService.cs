using LibraryManagerApp.Exceptions;
using LibraryManagerApp.Models;
using LibraryManagerApp.Repositories;

namespace LibraryManagerApp.Service
{
    public class AuthorService : IService<Author>
    {

        private readonly AuthorRepository authorRepository;

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

        public async Task DeleteAsync(int id)
        {
            bool deleted = await authorRepository.DeleteAsync(id);

            if (!deleted)
                throw new NotFoundInDatabaseException($"Author with id: {id} was not found");
        }

        public Task<IEnumerable<Author>> GetAllAsync()
        {
            return authorRepository.GetAllAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {

            Author? author = await authorRepository.GetByIdAsync(id);

            if (author == null)
                throw new NotFoundInDatabaseException($"Author with id: {id} was not found");

            return author;
            
        }

        public async Task<Author> UpdateAsync(int id, Author entity)
        {
      
            Author? updated = await authorRepository.UpdateAsync(id, entity);

            if (updated == null)
                throw new NotFoundInDatabaseException($"Author with id: {id} was not found");

            return updated;
        }
    }
}
