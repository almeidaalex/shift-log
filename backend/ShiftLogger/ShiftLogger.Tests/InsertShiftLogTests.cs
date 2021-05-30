using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using ShiftLogger.Domain;
using ShiftLogger.Tests.Fixtures;
using ShiftLogger.Tests.Helpers;
using Xunit;

namespace ShiftLogger.Tests
{
    public class InsertShiftLogTests : IClassFixture<DefaultHostFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly JsonDocument _document;

        public InsertShiftLogTests(DefaultHostFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();
            var requestContent = File.ReadAllText("Fixtures/Resources/InsertShiftLogRequest.json");
            _document = JsonDocument.Parse(requestContent);
        }
        
        [Fact]
        public async Task Should_insert_a_valid_shift_log()
        {
            var validRequest =  _document.GetRequest("valid_request");
            var requestBody = validRequest.AsContent();
            var resp = await _httpClient.PostAsync("api/shift", requestBody);

            resp.StatusCode.Should().Be(HttpStatusCode.Created);
            var body = resp.Content.ReadFromJsonAsync<ShiftLog>();
            body.Should().NotBeNull();
        }
        
        [Fact]
        public async Task Should_not_insert_a_shift_log_with_some_missing_fields()
        {
            var validRequest =  _document.GetRequest("missing_fields_request");
            var requestBody = validRequest.AsContent();
            var resp = await _httpClient.PostAsync("api/shift", requestBody);

            resp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}