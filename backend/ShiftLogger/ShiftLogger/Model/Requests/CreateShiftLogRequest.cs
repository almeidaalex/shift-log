using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShiftLogger.Infra;
using ShiftLogger.Model;

namespace ShiftLogger.Model.Requests
{
    public class CreateShiftLogRequest : IRequest<ShiftLog>, IRequestValidator
    {
        public string Area { get; set; }
        public DateTime EventDate { get; set; }
        public bool Status { get; set; }
        public string Machine { get; set; }
        public string Operator { get; set; }
        public string Comment { get; set; }

        public bool IsValid() => true;
    }

    public interface IRequestValidator
    {
        bool IsValid();
    }

    public class CreateShiftLogHandler : 
        IRequestHandler<CreateShiftLogRequest, ShiftLog>
    {
        private readonly IRepository<ShiftLog> _repository;

        public CreateShiftLogHandler(IRepository<ShiftLog> repository)
        {
            _repository = repository;
        }

        public async Task<ShiftLog> Handle(CreateShiftLogRequest request, CancellationToken cancellationToken)
        {
            var entity = new ShiftLog(request.Area, request.EventDate, request.Status, request.Machine, request.Operator, request.Comment);
            await _repository.AddAsync(entity);
            return entity;
        }
    }
}