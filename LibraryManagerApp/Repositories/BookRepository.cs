
using LibraryManagerApp.Models;
using LibraryManagerApp.Models.EFCoreMapping;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApp.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly LibraryContext _libraryContext;

        public BookRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;

        }


        public async Task<Book> AddAsync(Book book)
        {
            await _libraryContext.Books.AddAsync(book);
            await _libraryContext.SaveChangesAsync();

            return book;
        }

        public async Task DeleteAllAsync()
        {
            _libraryContext.Books.RemoveRange(_libraryContext.Books);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            _libraryContext.Books.Remove(book);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _libraryContext.Books.ToListAsync();

        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _libraryContext.Books.FindAsync(id);

        }

        public async Task<Book?> UpdateAsync(int id, Book entity)
        {
            Book? book = await _libraryContext.Books.FindAsync(id);

            if (book == null)
            {

                return null; //ten null bedzie obsłuzony w serwisie 
            }

            _libraryContext.Entry(book).CurrentValues.SetValues(entity);
            await _libraryContext.SaveChangesAsync();

            return book;
        }
    }
}
