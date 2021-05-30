using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using ShiftLogger.Tests.Fixtures;
using Xunit;

namespace ShiftLogger.Tests
{
    public class DeleteShiftLogTests : IClassFixture<DefaultHostFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public DeleteShiftLogTests(DefaultHostFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task Should_delete_successful_when_the_id_is_found()
        {
            var resp = await _httpClient.DeleteAsync("api/shift/10");
            resp.EnsureSuccessStatusCode();
            resp.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
        
        [Fact]
        public async Task Should_return_bad_request_when_it_not_possible_remove_shift()
        {
            var resp = await _httpClient.DeleteAsync("api/shift/9999999");
            resp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}