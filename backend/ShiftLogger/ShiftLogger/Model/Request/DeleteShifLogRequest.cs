using MediatR;

namespace ShiftLogger.Model.Request
{
    public class DeleteShifLogRequest : IRequest<Result>
    {
        public int Id { get; }

        public DeleteShifLogRequest(int id)
        {
            Id = id;
        }
    }
}