using System;
using MediatR;

namespace ShiftLogger.Model
{
    public class ShiftLog 
    {
        public ShiftLog(string area, DateTime eventDate, bool status, string machine, string @operator, string comment)
        {
            Area = area;
            EventDate = eventDate;
            Status = status;
            Machine = machine;
            Operator = @operator;
            Comment = comment;
        }
        
        public int Id  { get;  private set; }
        public string Area { get;  set; }
        public DateTime EventDate { get;  set; }
        public bool Status { get;  set; }
        public string Machine { get;  set; }
        public string Operator { get;  set; }
        public string Comment { get;  set; }
    }
}