using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ShiftLogger.Tests.Helpers
{
    internal static class RequestExtensions
    {
        internal static string AsJson<T>(this T model) where T : class =>        
            JsonSerializer.Serialize(model);

        internal static string GetRequest(this JsonDocument content, string key) =>
            content.RootElement.GetProperty(key).ToString();

        internal static StringContent AsContent(this string content) =>
            new (content, Encoding.UTF8, "application/json");
    }
}



