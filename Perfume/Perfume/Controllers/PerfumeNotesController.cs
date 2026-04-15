using Microsoft.AspNetCore.Mvc;
using Perfume.Data;
using Perfume.Models;

namespace Perfume.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerfumeNotesController : ControllerBase
    {
        private readonly PerfumeDbContext _context;

        public PerfumeNotesController(PerfumeDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<PerfumeNotes> GetById(int id) {
            var notes = _context.Notes.Find(id);
            if (notes == null) { return NotFound(); }
            else return Ok(notes);
        }

        [HttpPost]
        public ActionResult<PerfumeNotes> Create(PerfumeNotes newNotes)
        {
            _context.PerfumeNotes.Add(newNotes);
            _context.SaveChanges();
            return Ok(newNotes);
        }

        [HttpPut("{perfumeId}/{noteId}")]
        public IActionResult Update(PerfumeNotes updatedNotes, int perfumeId, int noteId)
        {
            if(perfumeId != updatedNotes.PerfumeId || noteId != updatedNotes.NoteId) { return BadRequest("id uyuşmazlığı"); }

            var existingNoteLink = _context.PerfumeNotes.Find(perfumeId, noteId);
            if (existingNoteLink == null) { return NotFound(); }

            existingNoteLink.Type = updatedNotes.Type; 
            
            _context.SaveChanges();
            return Ok(existingNoteLink);
        }

        [HttpDelete("{perfumeId}/{noteId}")]
        public IActionResult Delete(int perfumeId, int noteId)
        {
            var noteLink = _context.PerfumeNotes.Find(perfumeId, noteId);
            if (noteLink == null) { return NotFound(); }

            _context.PerfumeNotes.Remove(noteLink);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
