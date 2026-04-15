using Microsoft.AspNetCore.Mvc;
using Perfume.Data;
using System.Diagnostics.Eventing.Reader;
using Perfume.Models;

namespace Perfume.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {

        private readonly PerfumeDbContext _context;

        public NoteController(PerfumeDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Note> GetById(int id) 
        {
            var note = _context.Notes.Find(id);
            if (note == null) { return NotFound(); }
            else return Ok(note);
        }

        [HttpPost]
        public ActionResult<Note> Create(Note newNote) 
        { 
            _context.Notes.Add(newNote);
            _context.SaveChanges();
            return Ok(newNote);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Note updatedNote)
        {
            if (id != updatedNote.Id) { return BadRequest(); }

            var note = _context.Notes.Find(id);

            if(note == null) { return NotFound(); }

            note.Name = updatedNote.Name;

            _context.SaveChanges();
            return Ok(note);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var note = _context.Notes.Find(id);
            if (note == null) { return NotFound(); };

            _context.Notes.Remove(note);
            _context.SaveChanges();
            return NoContent();
        }
    }

}
