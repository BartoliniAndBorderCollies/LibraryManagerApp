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

        public Task<Author?> GetByIdAsync(int id)
        {
            return authorRepository.GetByIdAsync(id);
        }

        public Task<Author?> UpdateAsync(int id, Author entity)
        {
            return authorRepository.UpdateAsync(id, entity);
        }
    }
}
