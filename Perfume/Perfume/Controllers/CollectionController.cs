using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perfume.Data;
using Perfume.DTOs;
using Perfume.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Perfume.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CollectionController : ControllerBase
    {
        private readonly PerfumeDbContext _context;

        public CollectionController(PerfumeDbContext context) { 
            _context = context;
        }

        [HttpPost("add-to-collection")]
        public async Task<IActionResult> AddToCollection([FromBody] AddCollectionDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(userId == null) return Unauthorized("kullanıcı kimliği doğrulanamadı");

            var parfumExists = await _context.Perfumes.AnyAsync(p => p.Id == dto.PerfumeId);
            if(!parfumExists) return NotFound("sistemde böyle bir ürün bulunmamaktadır");

            var alreadyExists = await _context.CollectionItems.AnyAsync(c=>c.UserId == userId && c.PerfumeId == dto.PerfumeId);
            if (alreadyExists) return BadRequest("bu ürün zaten koleksiyonda bulunmaktadır");

            var collectionItem = new CollectionItem
            {
                UserId = userId,
                PerfumeId = dto.PerfumeId,
            };

            _context.CollectionItems.Add(collectionItem);
            await _context.SaveChangesAsync();
            return Ok("ürün başarıyla koleksiyona eklendi");
        }

    }

}
