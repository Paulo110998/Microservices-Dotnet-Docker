using PublishService.Dtos;
using System.Text;
using System.Text.Json;

namespace PublishService.Http;

public class ItemHttpClient : IItemHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public ItemHttpClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public void SendItem(ReadItemDto readItemDto)
    {
        var httpContent = new StringContent(
            JsonSerializer.Serialize(readItemDto),
            Encoding.UTF8,
            "application/json"
        );

        // Usando o método síncrono PostAsync().GetAwaiter().GetResult()
        var response = _httpClient.PostAsync($"{_configuration["ConsumerService"]}", httpContent)
                                  .GetAwaiter()
                                  .GetResult();

        // Opcional: Verificar o status da resposta
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to send item. Status Code: {response.StatusCode}");
        }
    }
}
