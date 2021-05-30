using System;
using Microsoft.EntityFrameworkCore;
using ShiftLogger.Domain;
using ShiftLogger.Infra;
using ShiftLogger.Model;
using Xunit;

namespace ShiftLogger.Tests.Fixtures
{
 
    public class UpdateFixture : IClassFixture<DefaultHostFactory<Startup>>
    {
        public UpdateFixture(DefaultHostFactory<Startup> factory)
        {
            var context = factory.GetDbContext<ShiftLoggerContext>();

            var log = new ShiftLog(id: 55,
                eventDate: new DateTime(2021, 02, 03),
                area: AreaEnum.ControlRoom,
                status: true,
                machine: "Machine 01",
                @operator: "Operator 01",
                comment: "unchanged comment"
            );
            context.ShiftLogs.Add(log);
            context.SaveChanges();
        }
    }
}