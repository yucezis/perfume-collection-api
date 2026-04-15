using Microsoft.AspNetCore.Mvc;
using Perfume.Data;
using Perfume.Models;

namespace Perfume.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionItemController : ControllerBase
    {
        private readonly PerfumeDbContext _context;

        public CollectionItemController(PerfumeDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public ActionResult<CollectionItem> GetById(int id) 
        { 
            var collectionItem = _context.CollectionItems.Find(id);
            if (collectionItem == null) {return NotFound();}
            else return Ok(collectionItem);
        }

        [HttpPost]
        public ActionResult<CollectionItem> Create(CollectionItem newCollectionItem)
        {
            _context.CollectionItems.Add(newCollectionItem);
            _context.SaveChanges();
            return Ok(newCollectionItem);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CollectionItem updatedCollectionItem)
        {
            if(id != updatedCollectionItem.Id) { return BadRequest(); }

            var item = _context.CollectionItems.Find(id);
            if (item == null) { return NotFound(); }

            item.TotalVolumeMl = updatedCollectionItem.TotalVolumeMl;
            item.RemainingVolumeMl = updatedCollectionItem.RemainingVolumeMl;
            item.IsFinished = updatedCollectionItem.IsFinished;
            item.PurchaseDate = updatedCollectionItem.PurchaseDate;
            item.PerfumeId = updatedCollectionItem.PerfumeId;

            _context.SaveChanges();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.CollectionItems.Find(id);
            if (item == null) { return NotFound(); }

            _context.CollectionItems.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
