using LibraryManagerApp.Models;
using LibraryManagerApp.Repositories;

namespace LibraryManagerApp.Service
{
    public class BookService : IService<Book>
    {

        private readonly BookRepository bookRepository;

        public BookService(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }


        public Task<Book> AddAsync(Book entity)
        {
            return bookRepository.AddAsync(entity);
        }

        public Task DeleteAllAsync()
        {
            return bookRepository.DeleteAllAsync();
        }

        public Task DeleteAsync(Book entity)
        {
            return bookRepository.DeleteAsync(entity);
        }

        public Task<IEnumerable<Book>> GetAllAsync()
        {
            return bookRepository.GetAllAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            Book? book = await bookRepository.GetByIdAsync(id);

            if (book == null)
                throw new KeyNotFoundException($"Book with id: {id} was not found!");

            return book;
        }

        public async Task<Book> UpdateAsync(int id, Book entity)
        {

            Book? updatedBook = await bookRepository.UpdateAsync(id, entity);

            if (updatedBook == null)
                throw new KeyNotFoundException($"Book with id {id} was not found!");

            return updatedBook;



        }
    }
}
