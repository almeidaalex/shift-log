using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftLogger.Domain
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(object id);
        T Update(T entity);
        void Delete(object id);
        Task<T> AddAsync(T entity);
    }
}