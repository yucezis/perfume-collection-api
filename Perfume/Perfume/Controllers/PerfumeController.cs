using Microsoft.AspNetCore.Mvc;
using Perfume.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Perfume.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PerfumeController : ControllerBase
    {
        private readonly Perfume.Data.PerfumeDbContext _context;

        public PerfumeController(Perfume.Data.PerfumeDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Perfume.Models.Perfume> GetById(int id)
        {
            var perfume = _context.Perfumes.Include(p=>p.Brand)
                            .Include(p=>p.PerfumeNotes)
                            .ThenInclude(pn=>pn.Note)
                            .FirstOrDefault(p=>p.Id == id);
            if (perfume == null) { return NotFound(); }
            else return Ok(perfume);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult<Perfume.Models.Perfume> Create(Perfume.Models.Perfume newPerfume)
        {
            _context.Perfumes.Add(newPerfume);
            _context.SaveChanges();
            return Ok(newPerfume);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, Perfume.Models.Perfume updatedPerfume) 
        {
            if (id != updatedPerfume.Id) { return BadRequest(); }

            var perfume = _context.Perfumes.Find(id);
            if (perfume == null) { return NotFound(); }

            perfume.Name = updatedPerfume.Name;
            perfume.ReleaseYear = updatedPerfume.ReleaseYear;
            perfume.BrandId = updatedPerfume.BrandId;
            perfume.Family = updatedPerfume.Family;

            _context.SaveChanges();
            return Ok(perfume);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id) 
        {
            var perfume = _context.Perfumes.Find(id);
            if (perfume == null) { return NotFound(); }

            _context.Perfumes.Remove(perfume);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
