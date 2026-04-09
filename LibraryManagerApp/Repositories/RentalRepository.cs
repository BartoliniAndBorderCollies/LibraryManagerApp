using LibraryManagerApp.Models;
using LibraryManagerApp.Models.EFCoreMapping;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApp.Repositories
{
    public class RentalRepository : IRepository<Rental>
    {

        private readonly LibraryContext _libraryContext;


        public RentalRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }


        public async Task<Rental> AddAsync(Rental entity)
        {
            await _libraryContext.Rentals.AddAsync(entity);
            await _libraryContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAllAsync()
        {
            _libraryContext.Rentals.RemoveRange(_libraryContext.Rentals);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Rental? rental = await _libraryContext.Rentals.FindAsync(id);

            if (rental == null)
                return false;

            _libraryContext.Rentals.Remove(rental);
            await _libraryContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Rental>> GetAllAsync()
        {
            return await _libraryContext.Rentals.ToListAsync();
        }

        public async Task<Rental?> GetByIdAsync(int id)
        {
            return await _libraryContext.Rentals.FindAsync(id);
        }

        public async Task<Rental?> UpdateAsync(int id, Rental entity)
        {
            Rental? rental = await _libraryContext.Rentals.FindAsync(id);

            if(rental == null)
            {
                return null;
            }

            _libraryContext.Entry(rental).CurrentValues.SetValues(entity);
            await _libraryContext.SaveChangesAsync();

            return rental;


        }
    }
}
