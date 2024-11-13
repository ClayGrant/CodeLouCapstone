using CodeLouCapstone.App.Components.Services;
using Microsoft.AspNetCore.Components;
using CodeLouCapstone.Shared;

namespace CodeLouCapstone.App.Components.Pages
{
    public partial class DeckEdit
    {
        [Inject]
        public IDeckService DeckService { get; set; }

        [Parameter]
        public string DeckId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Deck Deck { get; set; } = new Deck();
        public List<string> Cards { get; set; } = new List<string>();

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        private List<Card> _cards = new List<Card>();
        private string newCard;

        protected async override Task OnInitializedAsync()
        {
            Console.WriteLine($"OnInitializedAsync Was Called");

            Saved = false;

            int.TryParse(DeckId, out var deckId);

            if (deckId == 0)
            {
                Deck = new Deck();
            }
            else
            {
                Deck = await DeckService.GetDeck(int.Parse(DeckId));
                Cards = (await DeckService.GetDeckCards(int.Parse(DeckId))).ToList();
            }

            StateHasChanged();
        }

        protected async Task HandleValidCardSubmit()
        {
            Saved = false;

            var validCard = ValidateCards(newCard);

            if (validCard == true)
            {
                Saved = true;
            }
            else
            {
                Saved = false;
            }
        }

        protected async Task HandleInvalidCardSubmit()
        {
            Saved = false;
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            //need to differentiate between validsubmit for a deck and a card

            var validDeck = ValidateDeck(Deck);

            if (Deck.DeckId == 0 && validDeck == true)
            {
                var newDeck = await DeckService.AddDeck(Deck);
                if (newDeck != null)
                {
                    StatusClass = "alert-success";
                    Message = "New deck added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new deck. Please try again.";
                    Saved = false;
                }
            }
            else if (validDeck == true)
            {
                await DeckService.EditDeck(Deck);
                StatusClass = "alert-success";
                Message = "Deck edited successfully.";
                Saved = true;
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Deck does not meat Standard ruleset. Please try again.";
                Saved = false;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "Deck does not meet Standard ruleset. Please try again.";
        }

        protected async Task DeleteDeck()
        {
            await DeckService.DeleteDeck(Deck.DeckId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToDecks()
        {
            NavigationManager.NavigateTo("/decks");
        }

        private async Task AddCard()
        {
            if (!string.IsNullOrEmpty(newCard))
            {

                var cardLegal = ValidateCards(newCard);

                if (cardLegal == false)
                {
                    StatusClass = "alert-danger";
                    Message = "Card is not legal.";
                }
                else
                {
                    Deck.Cards.Add(newCard);
                    await DeckService.EditDeck(Deck);
                    Cards.Add(newCard);
                    newCard = string.Empty;
                }
            }
        }

        private async Task RemoveCard(string card)
        {
            Deck.Cards.Remove(card);
            await DeckService.EditDeck(Deck);

            var cardDeleted = Cards.FirstOrDefault(c => c == card);
            if (cardDeleted != null)
            {
                Cards.Remove(cardDeleted);
            }
        }

        private Boolean ValidateCards(string card)
        {
            foreach (string cardd in Cards)
            {
                if (card == cardd)
                {
                    return true;
                }
            }
            return false;
        }

        private Boolean ValidateDeck(Deck deck)
        {
            if (deck.Cards.Count < 60)
            {
                return false;
            }

            //ValidateCards(deck.Cards);
            return true;
        }
    }
}
