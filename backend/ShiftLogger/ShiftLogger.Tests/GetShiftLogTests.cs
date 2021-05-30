using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using ShiftLogger.Domain;
using ShiftLogger.Infra;
using ShiftLogger.Model;
using ShiftLogger.Tests.Fixtures;
using Xunit;

namespace ShiftLogger.Tests
{
    public class GetShiftLogTests : IClassFixture<DefaultHostFactory<Startup>>
    {
        private readonly DefaultHostFactory<Startup> _factory;
        private readonly HttpClient _httpClient;

        public GetShiftLogTests(DefaultHostFactory<Startup> factory)
        {
            _factory = factory;
            _httpClient = factory.CreateDefaultClient();
        }
        
        [Fact]
        public async Task Should_return_all_shifts_on_database()
        {
            var resp = await _httpClient.GetFromJsonAsync<IEnumerable<ShiftLogView>>("api/shift");
            resp.Should().HaveCountGreaterThan(10);
        }
        
        [Fact]
        public async Task Should_return_shift_log_view_by_id()
        {
            var resp = await _httpClient.GetFromJsonAsync<ShiftLogView>("api/shift/1");
            resp.Should().NotBeNull();
        }
        
      
    }
}