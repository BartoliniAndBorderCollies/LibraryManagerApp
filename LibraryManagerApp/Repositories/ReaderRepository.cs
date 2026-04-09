using LibraryManagerApp.Models;
using LibraryManagerApp.Models.EFCoreMapping;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApp.Repositories
{
    public class ReaderRepository : IRepository<Reader>
    {

        private readonly LibraryContext _libraryContext;

        public ReaderRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }


        public async Task<Reader> AddAsync(Reader entity)
        {
            await _libraryContext.Readers.AddAsync(entity);
            await _libraryContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAllAsync()
        {
            _libraryContext.Readers.RemoveRange(_libraryContext.Readers);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Reader? reader = await _libraryContext.Readers.FindAsync(id);

            if(reader == null)
                return false;

            _libraryContext.Readers.Remove(reader);
            await _libraryContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Reader>> GetAllAsync()
        {
           return await _libraryContext.Readers.ToListAsync();
        }

        public async Task<Reader?> GetByIdAsync(int id)
        {
            return await _libraryContext.Readers.FindAsync(id);
        }

        public async Task<Reader?> UpdateAsync(int id, Reader entity)
        {
            Reader? reader = await _libraryContext.Readers.FindAsync(id);

            if (reader == null)
            {
                return null;
            }

            _libraryContext.Entry(reader).CurrentValues.SetValues(entity);
            await _libraryContext.SaveChangesAsync();

            return reader;
        }
    }
}
