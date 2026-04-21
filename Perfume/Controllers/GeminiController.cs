using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Perfume.Services;
using Perfume.DTOs.Gemini;

namespace Perfume.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeminiController : ControllerBase
    {
        private readonly IGeminiService _gemini;

        public GeminiController(IGeminiService gemini)
        {
            _gemini = gemini;
        }

        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] AskRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Prompt))
                return BadRequest("Prompt boş olamaz.");

            var answer = await _gemini.AskAsync(request.Prompt);
            return Ok(new { answer });
        }

        

    }
}
