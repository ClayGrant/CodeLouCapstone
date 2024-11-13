using CodeLouCapstone.Shared;

namespace CodeLouCapstone.App.Components.Services
{
    public interface IDeckService
    {
        Task<IEnumerable<Deck>> GetAllDecks();
        Task<IEnumerable<string>> GetDeckCards(int deckId);
        Task<Deck> AddDeck(Deck deck);
        Task<Deck> GetDeck(int deckId);
        Task EditDeck(Deck deck);
        Task DeleteDeck(int deckId);
    }
}
