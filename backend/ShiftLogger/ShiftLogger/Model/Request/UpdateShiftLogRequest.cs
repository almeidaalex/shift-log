using System;
using MediatR;
using ShiftLogger.Domain;

namespace ShiftLogger.Model.Request
{
    public class UpdateShiftLogRequest : IRequest<Result<ShiftLog>>
    {
        public int Id { get; set; }
        public AreaEnum Area { get;  set; }
        public DateTime EventDate { get;  set; }
        public bool Status { get;  set; }
        public string Machine { get;  set; }
        public string Operator { get;  set; }
        public string Comment { get;  set; }
    }
}