using CodeLouCapstone.App.Components.Services;
using CodeLouCapstone.Shared;
using Microsoft.AspNetCore.Components;

namespace CodeLouCapstone.App.Components.Pages
{
    public partial class DeckList
    {
        [Parameter]
        public string DeckId { get; set; }
        public Deck Deck { get; set; } = new Deck();
        public List<string> Cards { get; set; }
        [Inject]
        public IDeckService DeckService { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Console.WriteLine($"OnInitializedAsync Was Called");

            Deck = await DeckService.GetDeck(int.Parse(DeckId));
            Cards = (await DeckService.GetDeckCards(int.Parse(DeckId))).ToList();

            StateHasChanged();
        }
    }
}
