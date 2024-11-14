using CodeLouCapstone.App.Components.Services;
using CodeLouCapstone.Shared;
using Microsoft.AspNetCore.Components;

namespace CodeLouCapstone.App.Components.Pages
{
    public partial class DeckList
    {
        //[Parameter]
        [Parameter] public int DeckId { get; set; }
        public Deck uDeck { get; set; } = new Deck();
        public List<string> Cards { get; set; }
        [Inject]
        public IDeckService DeckService { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Console.WriteLine($"OnInitializedAsync Was Called");

            uDeck = await DeckService.GetDeck(DeckId);
            Cards = (await DeckService.GetDeckCards(DeckId)).ToList();

            StateHasChanged();
        }
    }
}
