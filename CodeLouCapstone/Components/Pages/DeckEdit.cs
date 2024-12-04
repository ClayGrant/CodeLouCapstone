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
        private List<string> cardAlt = new List<string>();

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
                Cards = Deck.Cards;
                cardAlt = Deck.Cards;
            }

            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            var validDeck = ValidateDeck(Deck);

            if (Deck.DeckId == 0 && validDeck == true)
            {
                Deck.Cards = Cards;
                var newDeck = await DeckService.AddDeck(Deck);
                if (newDeck != null)
                {
                    StatusClass = "alert-success";
                    Message = "New deck added successfully.";
                    Saved = true;
                    StateHasChanged();
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
                Deck.Cards = Cards;
                await DeckService.EditDeck(Deck);
                StatusClass = "alert-success";
                Message = "Deck edited successfully.";
                Saved = true;
                StateHasChanged();
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

        private void AddCard()
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
                    Cards.Add(newCard);
                    newCard = string.Empty;
                    StateHasChanged();
                }
            }
        }

        private void RemoveCard(string card)
        {

            var cardDeleted = Cards.FirstOrDefault(c => c == card);
            if (cardDeleted != null)
            {
                Cards.Remove(cardDeleted);
                StateHasChanged();
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
            if(deck == null || deck.Cards == null)
            {
                return false;
            }
            if(deck.Cards.Count == 0)
            {
                return false;
            }
            if (deck.Cards.Count < 60)
            {
                return false;
            }

            //ValidateCards(deck.Cards);
            return true;
        }
    }
}
