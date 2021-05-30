using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using ShiftLogger.Domain;

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

        public ShiftLog Update(ShiftLog entity)
        {
            _context.ShiftLogs.Update(entity);
            return entity;
        }

        public void Delete(object id)
        {
            var entity = _context.ShiftLogs.Find(id);
            if (entity is ShiftLog)
                _context.ShiftLogs.Remove(entity);
        }

        public async Task<ShiftLog> AddAsync(ShiftLog entity)
        {
            if (entity is not null)
                await _context.ShiftLogs.AddAsync(entity);
            return entity;
        }

    }
}