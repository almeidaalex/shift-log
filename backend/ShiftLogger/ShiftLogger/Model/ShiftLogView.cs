using System;
using ShiftLogger.Domain;

namespace ShiftLogger.Model
{
    public class ShiftLogView
    {
        
        public ShiftLogView(int id, string area, DateTime eventDate, bool status, string machine, string @operator, string comment)
        {
            Id = id;
            Area = area;
            EventDate = eventDate;
            Status = status;
            Machine = machine;
            Operator = @operator;
            Comment = comment;
        }
        public int Id { get; set; }
        public string Area { get; set;  }
        public DateTime EventDate { get; set;  }
        public bool Status { get; set; }
        public string Machine { get; set; }
        public string Operator { get; set; }
        public string Comment { get;  set; }
        
        public static implicit operator ShiftLogView(ShiftLog entity)
        {
            return new(entity.Id, entity.Area.ToString(), entity.EventDate, entity.Status, entity.Machine, entity.Operator, entity.Comment);
        }   
    }
}