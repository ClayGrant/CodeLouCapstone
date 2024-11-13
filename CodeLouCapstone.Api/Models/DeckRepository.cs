using CodeLouCapstone.Shared;

namespace CodeLouCapstone.Api.Models
{
    public class DeckRepository : IDeckRepository
    {
        private readonly AppDataContext _context;

        public DeckRepository(AppDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Deck> GetAllDecks()
        {
            return _context.Decks;
        }

        public Deck GetDeckById(int id)
        {
            return _context.Decks.FirstOrDefault(d => d.DeckId == id);
        }

        public Deck AddDeck(Deck deck)
        {
            var toAdd = _context.Decks.Add(deck);
            _context.SaveChanges();
            return toAdd.Entity;
        }

        public Deck UpdateDeck(Deck deck)
        {
            var deckExsists = _context.Decks.FirstOrDefault(d => d.DeckId == deck.DeckId);

            if (deckExsists != null)
            {
                deckExsists.Cards = deck.Cards;

                _context.SaveChanges();

                return deckExsists;
            }

            return null;
        }

        public void DeleteDeck(int id)
        {
            var deckExsists = _context.Decks.FirstOrDefault(d => d.DeckId == id);
            if (deckExsists == null) return;

            _context.Remove(deckExsists);
            _context.SaveChanges();
        }
    }
}
