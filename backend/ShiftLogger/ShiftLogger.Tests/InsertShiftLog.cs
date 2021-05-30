using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using ShiftLogger.Tests.Fixtures;
using ShiftLogger.Tests.Helpers;
using Xunit;

namespace ShiftLogger.Tests
{
    [Collection(CollectionNames.ShiftLoggerCollection)]
    public class InsertShiftLog : IClassFixture<DefaultHostFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly JsonDocument _document;

        public InsertShiftLog(DefaultHostFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();
            var requestContent = File.ReadAllText("Fixtures/Resources/InsertShiftLogRequest.json");
            _document = JsonDocument.Parse(requestContent);
        }
        
        [Fact]
        public async Task Insert_a_valid_shift_log()
        {
            var validRequest =  _document.GetRequest("valid_request");
            var requestBody = validRequest.AsContent();
            var resp = await _httpClient.PostAsync("api/shift", requestBody);

            resp.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}