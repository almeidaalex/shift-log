using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ShiftLogger.Tests.Fixtures
{
    public static class CollectionNames
    {
        public const string ShiftLoggerCollection = "ShiftLoggerIntegrationTest";
    }
    
    [CollectionDefinition(CollectionNames.ShiftLoggerCollection)]
    public class DefaultTestCollection : ICollectionFixture<DefaultHostFactory<Startup>>        
    {
        
    }
    
    public class DefaultHostFactory<TStartup> : WebApplicationFactory<TStartup>, IDisposable
        where TStartup : class
    {
        
    }
}