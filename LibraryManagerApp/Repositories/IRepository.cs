using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApp.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(); //tylko po odczycie wiec lepiej interfejs Enumerable
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T?> UpdateAsync(int id, T entity);
        Task DeleteAsync(T entity);
        Task DeleteAllAsync();
    }

}
