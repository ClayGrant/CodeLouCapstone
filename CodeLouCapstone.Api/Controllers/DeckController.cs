using Microsoft.AspNetCore.Mvc;
using CodeLouCapstone.Api.Models;
using CodeLouCapstone.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CodeLouCapstone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : Controller
    {
        private readonly IDeckRepository _deckRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeckController(IDeckRepository deckRepository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _deckRepository = deckRepository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult GetAllDecks()
        {
            return Ok(_deckRepository.GetAllDecks());
        }

        [HttpGet("{id}")]
        public IActionResult GetDeckById(int id)
        {
            return Ok(_deckRepository.GetDeckById(id));
        }

        [HttpPost]
        public IActionResult AddDeck([FromBody] Deck deck)
        {
            if (deck == null) return BadRequest();
            if (deck.DeckName == string.Empty)
            {
                ModelState.AddModelError("Deckname", "Deck name is required");
            }
            if (!ModelState.IsValid) return BadRequest();

            string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;

            var addedDeck = _deckRepository.AddDeck(deck);

            return Created("deck", addedDeck);
        }

        [HttpPut]
        public IActionResult EditDeck([FromBody] Deck deck)
        {
            if (deck == null) return BadRequest();
            if (deck.DeckName == string.Empty)
            {
                ModelState.AddModelError("Deckname", "Deck name is required");
            }
            if (!ModelState.IsValid) return BadRequest();

            var editDeck = _deckRepository.GetDeckById(deck.DeckId);

            if (editDeck == null) return NotFound();

            _deckRepository.UpdateDeck(deck);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDeck(int id)
        {
            if (id == 0) return BadRequest();

            var deleteDeck = _deckRepository.GetDeckById(id);

            if (deleteDeck == null) return NotFound();

            _deckRepository.DeleteDeck(id);

            return NoContent();
        }
    }
}
