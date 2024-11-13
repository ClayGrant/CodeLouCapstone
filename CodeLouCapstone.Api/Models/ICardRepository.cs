using CodeLouCapstone.Shared;

namespace CodeLouCapstone.Api.Models
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAllCards();
    }
}
