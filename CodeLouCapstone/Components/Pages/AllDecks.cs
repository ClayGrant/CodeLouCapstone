using CodeLouCapstone.App.Components.Services;
using CodeLouCapstone.Shared;
using Microsoft.AspNetCore.Components;

namespace CodeLouCapstone.App.Components.Pages
{
    public partial class AllDecks
    {
        [Inject]
        public IDeckService DeckService { get; set; }
        public List<Deck> Decks { get; set; }
        public int count { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Console.WriteLine($"OnInitializedAsync Was Called");

            Decks = (await DeckService.GetAllDecks()).ToList();
            count = Decks.Count();

            StateHasChanged();
        }

    }
}
