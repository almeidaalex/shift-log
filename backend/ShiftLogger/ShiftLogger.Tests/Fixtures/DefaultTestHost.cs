using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using ShiftLogger.Domain;
using ShiftLogger.Infra;
using ShiftLogger.Model;
using Xunit;

namespace ShiftLogger.Tests.Fixtures
{
    public static class CollectionNames
    {
        public const string ShiftLoggerCollection = "ShiftLoggerIntegrationTest";
    }
    
    
    public class DefaultHostFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        public DefaultHostFactory()
        {
            SeedShiftLogData(10).GetAwaiter();
        }
        
        private async Task SeedShiftLogData(short numberOfShifts)
        {
            await using var db = this.GetDbContext<ShiftLoggerContext>();
            for (var s = 0; s < numberOfShifts; s++)
            {
                var log = new ShiftLog(
                    eventDate: new DateTime(2021, 02, 03),
                    area: AreaEnum.ControlRoom,
                    status: true,
                    machine: $"Machine {s}",
                    @operator: $"Operator {s}",
                    comment: "some comments"
                );
                db.ShiftLogs.Add(log);
            }
            await db.SaveChangesAsync();
        }
        
        public T GetDbContext<T>()
        {
            var scope = this.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<T>();
            return db;
        }

    }
}