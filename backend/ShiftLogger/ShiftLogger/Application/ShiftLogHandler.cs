using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShiftLogger.Domain;
using ShiftLogger.Model;
using ShiftLogger.Model.Request;

namespace ShiftLogger.Application
{
    public class ShiftLogHandler : 
        IRequestHandler<CreateShiftLogRequest, Result<ShiftLog>>,
        IRequestHandler<UpdateShiftLogRequest, Result<ShiftLog>>,
        IRequestHandler<DeleteShifLogRequest, Result>
    {
        private readonly IRepository<ShiftLog> _repository;

        public ShiftLogHandler(IRepository<ShiftLog> repository)
        {
            _repository = repository;
        }
        
        public async Task<Result<ShiftLog>> Handle(CreateShiftLogRequest request, CancellationToken cancellationToken)
        {
            var newShift = new ShiftLog(request.Area, request.EventDate, request.Status, request.Machine,
                request.Operator, request.Comment);
            return Result.Ok(await _repository.AddAsync(newShift));
        }

        public Task<Result<ShiftLog>> Handle(UpdateShiftLogRequest request, CancellationToken cancellationToken)
        {
            var log = _repository.Get(request.Id);
            if (log is not ShiftLog)
                return Task.FromResult(Result.Fail<ShiftLog>("Log not found"));
            
            log.Area = request.Area;
            log.Comment = request.Comment;
            log.Machine = request.Machine;
            log.Operator = request.Operator;
            log.Status = request.Status;
            log.EventDate = request.EventDate;
                
            return Task.FromResult(Result.Ok(_repository.Update(log)));     
            
        }

        public Task<Result> Handle(DeleteShifLogRequest request, CancellationToken cancellationToken)
        {
            var log = _repository.Get(request.Id);
            if (log is not ShiftLog)
                return Task.FromResult(Result.Fail($"Shift log with id {request.Id} not found"));
            
            _repository.Delete(request.Id);
            return Task.FromResult(Result.Ok());
        }
    }
}