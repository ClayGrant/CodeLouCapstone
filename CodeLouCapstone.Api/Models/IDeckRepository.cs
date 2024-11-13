using CodeLouCapstone.Shared;

namespace CodeLouCapstone.Api.Models
{
    public interface IDeckRepository
    {
        IEnumerable<Deck> GetAllDecks();
        Deck GetDeckById(int id);
        Deck AddDeck(Deck deck);
        Deck UpdateDeck(Deck deck);
        void DeleteDeck(int id);
    }
}
