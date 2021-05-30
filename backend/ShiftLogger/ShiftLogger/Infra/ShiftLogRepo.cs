using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using ShiftLogger.Model;

namespace ShiftLogger.Infra
{
    public class ShiftLogRepo : IRepository<ShiftLog>
    {
        private readonly ShiftLoggerContext _context;

        public ShiftLogRepo(ShiftLoggerContext context)
        {
            _context = context;
        }
        
        public IEnumerable<ShiftLog> GetAll() =>
            _context.ShiftLogs.ToImmutableArray();


        public ShiftLog Get(object id) =>
            _context.ShiftLogs.Find(id);

        public void Update(ShiftLog entity)
        {
            _context.ShiftLogs.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            var entity = _context.ShiftLogs.Find(id);
            if (entity is ShiftLog)
                _context.ShiftLogs.Remove(entity);
        }

        public Task AddAsync(ShiftLog entity)
        {
            if (entity is not null)
                _context.ShiftLogs.Add(entity);
            return Task.CompletedTask;
        }

    }
}