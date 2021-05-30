using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftLogger.Infra
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(object id);
        void Update(T entity);
        void Delete(object id);
        Task AddAsync(T entity);
    }
}