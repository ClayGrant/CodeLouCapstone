using CodeLouCapstone.Shared;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace CodeLouCapstone.App.Components.Services
{
    public class DeckService : IDeckService
    {
        private readonly HttpClient _httpClient;

        public DeckService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Deck>> GetAllDecks()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Deck>>
                    (await _httpClient.GetStreamAsync($"api/Deck"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            /*try
            {
                var response = await _httpClient.GetAsync($"https://localhost:7226/api/Deck");

                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    var decks = await JsonSerializer.DeserializeAsync<IEnumerable<Deck>>(responseStream);
                    return decks ?? Enumerable.Empty<Deck>();
                }
                else
                {
                    Console.Error.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    throw new HttpRequestException($"Failed to fetch decks: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                // Log and rethrow or handle the exception as needed
                Console.Error.WriteLine($"Request failed: {ex.Message}");
                throw;  // Rethrow to propagate the exception
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                Console.Error.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }*/

        }

        public async Task<IEnumerable<string>> GetDeckCards(int deckId)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>
                    (await _httpClient.GetStreamAsync($"api/Deck/{deckId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Deck> GetDeck(int deckId)
        {
            return await JsonSerializer.DeserializeAsync<Deck>
                    (await _httpClient.GetStreamAsync($"api/Deck/{deckId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Deck> AddDeck(Deck deck)
        {
            var deckJson =
                new StringContent(JsonSerializer.Serialize(deck), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Deck", deckJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Deck>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task EditDeck(Deck deck)
        {
            var deckJson =
                new StringContent(JsonSerializer.Serialize(deck), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/Deck", deckJson);
        }

        public async Task DeleteDeck(int deckId)
        {
            await _httpClient.DeleteAsync($"api/Deck/{deckId}");
        }
    }
}
