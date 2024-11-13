using CodeLouCapstone.Shared;
using System.Text.Json;

namespace CodeLouCapstone.App.Components.Services
{
    public class CardService : ICardService
    {
        private readonly HttpClient _httpClient;

        public CardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Card>> GetAllCards()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Card>>
                    (await _httpClient.GetStreamAsync($"api/card"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
