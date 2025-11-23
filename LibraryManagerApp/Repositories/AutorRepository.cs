using LibraryManagerApp.Models;
using LibraryManagerApp.Models.EFCoreMapping;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApp.Repositories
{
    public class AutorRepository : IRepository<Autor>
    {
        //readonly - pole może być przypisane tylko raz: w momencie deklaracji lub w konstruktorze
        private readonly LibraryContext _libraryContext;

        public AutorRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<Autor> AddAsync(Autor entity)
        {
            await _libraryContext.Autorzy.AddAsync(entity);
            await _libraryContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAllAsync()
        {
            _libraryContext.Autorzy.RemoveRange(_libraryContext.Autorzy); //kolekcja do usuniecia
            await _libraryContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Autor entity)
        {
            _libraryContext.Autorzy.Remove(entity);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Autor>> GetAllAsync()
        {
            return await _libraryContext.Autorzy.ToListAsync();
        }

        public async Task<Autor?> GetByIdAsync(int id)
        {

            Autor? autor = await _libraryContext.Autorzy.FindAsync(id);
            return autor;

        }

        public async Task<Autor?> UpdateAsync(int id, Autor entity)
        {
            Autor? autor = await _libraryContext.Autorzy.FindAsync(id);

            if(autor == null)
            {
                return null; //serwis zdecyduje co dalej
            }

            _libraryContext.Entry(autor).CurrentValues.SetValues(entity);
            await _libraryContext.SaveChangesAsync();
            return autor;

        }
    }
}
