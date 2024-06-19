using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Models;
using quan_li_app.Models.DataDB.QuanLiNhanSu;

namespace quan_li_app.Controllers.QuanLiNhanSu
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryAndBenefitsController : ControllerBase
    {
        private readonly DataContext _context;

        public SalaryAndBenefitsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SalaryAndBenefits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaryAndBenefits>>> GetSalaryAndBenefits()
        {
            return await _context.SalaryAndBenefits.ToListAsync();
        }

        // GET: api/SalaryAndBenefits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryAndBenefits>> GetSalaryAndBenefits(string id)
        {
            var salaryAndBenefits = await _context.SalaryAndBenefits.FindAsync(id);

            if (salaryAndBenefits == null)
            {
                return NotFound();
            }

            return salaryAndBenefits;
        }

        // PUT: api/SalaryAndBenefits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaryAndBenefits(string id, SalaryAndBenefits salaryAndBenefits)
        {
            if (id != salaryAndBenefits.id)
            {
                return BadRequest();
            }

            _context.Entry(salaryAndBenefits).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryAndBenefitsExists(id))
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

        // POST: api/SalaryAndBenefits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalaryAndBenefits>> PostSalaryAndBenefits(SalaryAndBenefits salaryAndBenefits)
        {
            _context.SalaryAndBenefits.Add(salaryAndBenefits);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalaryAndBenefitsExists(salaryAndBenefits.id!))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalaryAndBenefits", new { salaryAndBenefits.id }, salaryAndBenefits);
        }

        // DELETE: api/SalaryAndBenefits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalaryAndBenefits(string id)
        {
            var salaryAndBenefits = await _context.SalaryAndBenefits.FindAsync(id);
            if (salaryAndBenefits == null)
            {
                return NotFound();
            }

            _context.SalaryAndBenefits.Remove(salaryAndBenefits);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaryAndBenefitsExists(string id)
        {
            return _context.SalaryAndBenefits.Any(e => e.id == id);
        }
    }
}
