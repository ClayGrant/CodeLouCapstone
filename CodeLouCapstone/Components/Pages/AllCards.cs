using CodeLouCapstone.App.Components.Services;
using CodeLouCapstone.Shared;
using Microsoft.AspNetCore.Components;

namespace CodeLouCapstone.App.Components.Pages
{
    public partial class AllCards
    {
        [Inject]
        public ICardService CardService { get; set; }
        public List<Card> Cards { get; set; }
        public int count { get; set; }
        protected async override Task OnInitializedAsync()
        {

            //Cards = (await CardService.GetAllCards()).ToList();
            Cards = (await CardService.GetAllCards()).ToList();
            count = Cards.Count();

            Console.WriteLine($"OnInitializedAsync Was Called");
            StateHasChanged();


        }
    }
}
