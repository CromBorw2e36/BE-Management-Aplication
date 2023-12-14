using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Models;
using quan_li_app.Models.DataDB.QuanLiNhanSu;

namespace quan_li_app.Controllers.QuanLiNhanSu
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentJobPositionsController : ControllerBase
    {
        private readonly DataContext _context;

        public CurrentJobPositionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CurrentJobPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrentJobPosition>>> GetCurrentJobPositions()
        {
            return await _context.CurrentJobPositions.ToListAsync();
        }

        // GET: api/CurrentJobPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrentJobPosition>> GetCurrentJobPosition(string id)
        {
            var currentJobPosition = await _context.CurrentJobPositions.FindAsync(id);

            if (currentJobPosition == null)
            {
                return NotFound();
            }

            return currentJobPosition;
        }

        // PUT: api/CurrentJobPositions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrentJobPosition(string id, CurrentJobPosition currentJobPosition)
        {
            if (id != currentJobPosition.id)
            {
                return BadRequest();
            }

            _context.Entry(currentJobPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrentJobPositionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CurrentJobPositions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CurrentJobPosition>> PostCurrentJobPosition(CurrentJobPosition currentJobPosition)
        {
            _context.CurrentJobPositions.Add(currentJobPosition);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CurrentJobPositionExists(currentJobPosition.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCurrentJobPosition", new { currentJobPosition.id }, currentJobPosition);
        }

        // DELETE: api/CurrentJobPositions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrentJobPosition(string id)
        {
            var currentJobPosition = await _context.CurrentJobPositions.FindAsync(id);
            if (currentJobPosition == null)
            {
                return NotFound();
            }

            _context.CurrentJobPositions.Remove(currentJobPosition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CurrentJobPositionExists(string id)
        {
            return _context.CurrentJobPositions.Any(e => e.id == id);
        }
    }
}
