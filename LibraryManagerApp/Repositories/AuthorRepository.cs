using LibraryManagerApp.Models;
using LibraryManagerApp.Models.EFCoreMapping;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApp.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        //readonly - pole może być przypisane tylko raz: w momencie deklaracji lub w konstruktorze
        private readonly LibraryContext _libraryContext;

        public AuthorRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<Author> AddAsync(Author entity)
        {
            await _libraryContext.Authors.AddAsync(entity);
            await _libraryContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAllAsync()
        {
            _libraryContext.Authors.RemoveRange(_libraryContext.Authors); //kolekcja do usuniecia
            await _libraryContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Author entity)
        {
            _libraryContext.Authors.Remove(entity);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _libraryContext.Authors.ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {

            Author? author = await _libraryContext.Authors.FindAsync(id);
            return author;

        }

        public async Task<Author?> UpdateAsync(int id, Author entity)
        {
            Author? author = await _libraryContext.Authors.FindAsync(id);

            if(author == null)
            {
                return null; //serwis zdecyduje co dalej
            }

            _libraryContext.Entry(author).CurrentValues.SetValues(entity);
            await _libraryContext.SaveChangesAsync();
            return author;

        }
    }
}
