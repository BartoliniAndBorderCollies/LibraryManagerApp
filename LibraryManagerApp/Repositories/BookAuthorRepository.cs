using LibraryManagerApp.Models;
using LibraryManagerApp.Models.EFCoreMapping;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApp.Repositories
{
    public class BookAuthorRepository
    {
        public readonly LibraryContext _libraryContext;

        public BookAuthorRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;

        }

        public async Task<Book_Author> AddAsync(Book_Author entity)
        {
            await _libraryContext.BooksAuthors.AddAsync(entity);
            await _libraryContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAllAsync()
        {
            _libraryContext.BooksAuthors.RemoveRange(_libraryContext.BooksAuthors);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book_Author entity)
        {
            _libraryContext.BooksAuthors.Remove(entity);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book_Author>> GetAllAsync()
        {
            return await _libraryContext.BooksAuthors.ToListAsync();

        }

        public async Task<Book_Author?> GetByIdsAsync(int bookId, int authorId)
        {
            return await _libraryContext.BooksAuthors
                .FirstOrDefaultAsync(x => x.BookId == bookId && x.AuthorId == authorId);
        }


        public async Task<Book_Author?> UpdateAsync(int bookId, int authorId, Book_Author entity)
        {
            Book_Author? book_author = await _libraryContext.BooksAuthors
                .FirstOrDefaultAsync(x => x.BookId == bookId && x.AuthorId == authorId);

            if (book_author == null) //w serwisie obróbka tego
            {
                return null;
            }

            _libraryContext.Entry(book_author).CurrentValues.SetValues(entity);
            await _libraryContext.SaveChangesAsync();

            return book_author;

        }
    }
}
