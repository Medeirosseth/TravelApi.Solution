using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace TravelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly TravelApiContext _db;

        public ReviewsController(TravelApiContext db)
        {
            _db = db;
        }

        private bool ReviewExists(int id) => _db.Reviews.Any(a => a.ReviewId == id);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> Get()
        => await _db.Reviews.ToListAsync();
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _db.Reviews.FindAsync(id);
            if (review == null) return NotFound();
            return review;
        }

        [HttpPost]
        public async Task<ActionResult<Review>> Post(Review r)
        {
            _db.Reviews.Add(r);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReview), new { id = r.ReviewId }, r);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Review r)
        {
        if (id != r.ReviewId) return BadRequest();

        _db.Entry(r).State = EntityState.Modified;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReviewExists(id)) return NotFound();
            else throw;
        }
        return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
        Review r = await _db.Reviews.FindAsync(id);
        if (r == null) return NotFound();

        _db.Reviews.Remove(r);
        await _db.SaveChangesAsync();

        return NoContent();
        }
    }
}
