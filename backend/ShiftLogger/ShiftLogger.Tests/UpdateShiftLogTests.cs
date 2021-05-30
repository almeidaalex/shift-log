using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using ShiftLogger.Domain;
using ShiftLogger.Infra;
using ShiftLogger.Model;
using ShiftLogger.Tests.Fixtures;
using ShiftLogger.Tests.Helpers;
using Xunit;

namespace ShiftLogger.Tests
{
    public class UpdateShiftLogTests : IClassFixture<DefaultHostFactory<Startup>>
    {
        private readonly DefaultHostFactory<Startup> _factory;
        private readonly HttpClient _httpClient;
        private readonly JsonDocument _document;

        public UpdateShiftLogTests(DefaultHostFactory<Startup> factory)
        {
            _factory = factory;
            _httpClient = factory.CreateDefaultClient();
            var requestContent = File.ReadAllText("Fixtures/Resources/UpdateShiftLogRequest.json");
            _document = JsonDocument.Parse(requestContent);
        }
        
        [Fact]
        public async Task Should_update_a_valid_shift_request()
        {
            await SeedShiftLogData();
                
            var content = _document.GetRequest("valid_request").AsContent();
            var resp = await _httpClient.PutAsync("api/shift/55", content);
            resp.StatusCode.Should().Be(HttpStatusCode.OK);
            var body = await resp.Content.ReadFromJsonAsync<ShiftLog>();
            body.Comment.Should().Be("Changed comment");
        }
        
        [Fact]
        public async Task Should_return_bad_request_for_invalid_request()
        {       
            var content = _document.GetRequest("missing_fields_request").AsContent();
            var resp = await _httpClient.PutAsync("api/shift/56", content);
            resp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        private async Task SeedShiftLogData()
        {
            await using var db = _factory.GetDbContext<ShiftLoggerContext>();
            var log = new ShiftLog(id: 55,
                eventDate: new DateTime(2021, 02, 03),
                area: AreaEnum.ControlRoom,
                status: true,
                machine: "Machine 01",
                @operator: "Operator 01",
                comment: "unchanged comment"
            );
            db.ShiftLogs.Add(log);
            await db.SaveChangesAsync();
        }
    }
}