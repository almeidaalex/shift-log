using System;
using MediatR;
using ShiftLogger.Domain;
using ShiftLogger.Model;

namespace ShiftLogger.Model.Requests
{
    public class UpdateShiftLogRequest : IRequest<ShiftLog>
    {
        
        public string Area { get; set; }
        public DateTime EventDate { get; set; }
        public bool Status { get; set; }
        public string Machine { get; set; }
        public string Operator { get; set; }
        public string Comment { get; set; }
    }
}