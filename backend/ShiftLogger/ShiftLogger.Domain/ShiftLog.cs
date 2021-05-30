using System;
using ShiftLogger.Model;

namespace ShiftLogger.Domain
{
    public class ShiftLog 
    {
        //remover depois
        public ShiftLog()
        {
            
        }
        public ShiftLog(AreaEnum area, DateTime eventDate, bool status, string machine, string @operator, string comment)
        {
            Area = area;
            EventDate = eventDate;
            Status = status;
            Machine = machine;
            Operator = @operator;
            Comment = comment;
        }

        public ShiftLog(int id, AreaEnum area, DateTime eventDate, bool status, string machine, string @operator, string comment)
            : this(area, eventDate, status, machine, @operator, comment)
        {
            Id = id;
        }
        
        public int Id  { get;  private set; }
        public AreaEnum Area { get;  set; }
        public DateTime EventDate { get;  set; }
        public bool Status { get;  set; }
        public string Machine { get;  set; }
        public string Operator { get;  set; }
        public string Comment { get;  set; }
    }
}