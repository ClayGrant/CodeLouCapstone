using CodeLouCapstone.Shared;

namespace CodeLouCapstone.Api.Models
{
    public class CardRepository : ICardRepository
    {
        private readonly AppDataContext _context;

        public CardRepository(AppDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Card> GetAllCards()
        {
            return _context.Cards;
        }
    }
}
