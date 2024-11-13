using Microsoft.AspNetCore.Mvc;
using CodeLouCapstone.Api.Models;
using CodeLouCapstone.Shared;

namespace CodeLouCapstone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : Controller
    {
        private readonly ICardRepository _cardRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CardController(ICardRepository cardRepository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _cardRepository = cardRepository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult GetAllCards()
        {
            return Ok(_cardRepository.GetAllCards());
        }
    }
}
