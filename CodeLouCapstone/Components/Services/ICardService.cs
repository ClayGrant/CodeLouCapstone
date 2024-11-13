using CodeLouCapstone.Shared;

namespace CodeLouCapstone.App.Components.Services
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> GetAllCards();
    }
}
