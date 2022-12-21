using System.Text;
using System.Text.Json;

namespace lab5.Services;

public static class RestTemplate
{
    private static readonly string apiBasicUri = "http://127.0.0.1:5188";

    public static async Task<T> Post<T>(string url, object? contentValue)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiBasicUri);
            var content = new StringContent(JsonSerializer.Serialize(contentValue), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);
            result.EnsureSuccessStatusCode();
            var resultContentString = await result.Content.ReadAsStringAsync();
            var resultContent = JsonSerializer.Deserialize<T>(resultContentString)!;
            return resultContent;
        }
    }

    public static async Task Put<T>(string url, T stringValue)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiBasicUri);
            var content = new StringContent(JsonSerializer.Serialize(stringValue), Encoding.UTF8, "application/json");
            var result = await client.PutAsync(url, content);
            result.EnsureSuccessStatusCode();
        }
    }

    public static async Task<T> Get<T>(string url)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiBasicUri);
            var result = await client.GetAsync(url);
            result.EnsureSuccessStatusCode();
            var resultContentString = await result.Content.ReadAsStringAsync();
            var resultContent = JsonSerializer.Deserialize<T>(resultContentString)!;
            return resultContent;
        }
    }

    public static async Task Delete(string url)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiBasicUri);
            var result = await client.DeleteAsync(url);
            result.EnsureSuccessStatusCode();
        }
    }
}