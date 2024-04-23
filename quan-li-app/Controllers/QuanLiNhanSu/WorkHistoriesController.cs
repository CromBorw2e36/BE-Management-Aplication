using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Models;
using quan_li_app.Models.DataDB.QuanLiNhanSu;

namespace quan_li_app.Controllers.QuanLiNhanSu
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkHistoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public WorkHistoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/WorkHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkHistory>>> GetWorkHistories()
        {
            return await _context.WorkHistories.ToListAsync();
        }

        // GET: api/WorkHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkHistory>> GetWorkHistory(string id)
        {
            var workHistory = await _context.WorkHistories.FindAsync(id);

            if (workHistory == null)
            {
                return NotFound();
            }

            return workHistory;
        }

        // PUT: api/WorkHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkHistory(string id, WorkHistory workHistory)
        {
            if (id != workHistory.id)
            {
                return BadRequest();
            }

            _context.Entry(workHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkHistoryExists(id))
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

        // POST: api/WorkHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorkHistory>> PostWorkHistory(WorkHistory workHistory)
        {
            _context.WorkHistories.Add(workHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorkHistoryExists(workHistory.id!))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWorkHistory", new { workHistory.id }, workHistory);
        }

        // DELETE: api/WorkHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkHistory(string id)
        {
            var workHistory = await _context.WorkHistories.FindAsync(id);
            if (workHistory == null)
            {
                return NotFound();
            }

            _context.WorkHistories.Remove(workHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkHistoryExists(string id)
        {
            return _context.WorkHistories.Any(e => e.id == id);
        }
    }
}
