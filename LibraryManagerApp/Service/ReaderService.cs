using LibraryManagerApp.Exceptions;
using LibraryManagerApp.Models;
using LibraryManagerApp.Repositories;

namespace LibraryManagerApp.Service
{
    public class ReaderService : IService<Reader>
    {

        private readonly IRepository<Reader> _readerRepository;

        public ReaderService(ReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }



        public Task<Reader> AddAsync(Reader entity)
        {
            return _readerRepository.AddAsync(entity);
        }

        public Task DeleteAllAsync()
        {
            return _readerRepository.DeleteAllAsync();
        }

        public async Task DeleteAsync(int id)
        {

            bool deleted = await _readerRepository.DeleteAsync(id);

            if (!deleted)
                throw new NotFoundInDatabaseException($"Reader with id: {id} was not found!");


        }

        public Task<IEnumerable<Reader>> GetAllAsync()
        {
            return _readerRepository.GetAllAsync();
        }

        public async Task<Reader> GetByIdAsync(int id)
        {
            Reader? reader = await _readerRepository.GetByIdAsync(id);

            if (reader == null)
                throw new NotFoundInDatabaseException($"Reader with id: {id} was not found!");

            return reader;
        }

        public async Task<Reader> UpdateAsync(int id, Reader entity)
        {
            Reader? reader = await _readerRepository.UpdateAsync(id, entity);

            if (reader == null)
                throw new NotFoundInDatabaseException($"Reader with id: {id} was not found!");

            return reader;
        }
    }
}
