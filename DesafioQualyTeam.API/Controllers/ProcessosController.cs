using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioQualyTeam.API.Data;
using DesafioQualyTeam.API.Entities;

namespace DesafioQualyTeam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProcessosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Processos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Processo>>> GetProcessos()
        {
            return await _context.Processos
                .OrderBy(e => e.Nome)
                .AsNoTracking()
                .ToListAsync();
        }

        // GET: api/Processos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Processo>> GetProcesso(Guid id)
        {
            var processo = await _context.Processos.FindAsync(id);

            if (processo == null)
            {
                return NotFound();
            }

            return processo;
        }

        // PUT: api/Processos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcesso(Guid id, Processo processo)
        {
            if (id != processo.Id)
            {
                return BadRequest();
            }

            _context.Entry(processo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessoExists(id))
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

        // POST: api/Processos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Processo>> PostProcesso(Processo processo)
        {
            _context.Processos.Add(processo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcesso", new { id = processo.Id }, processo);
        }

        // DELETE: api/Processos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcesso(Guid id)
        {
            var processo = await _context.Processos.FindAsync(id);
            if (processo == null)
            {
                return NotFound();
            }

            _context.Processos.Remove(processo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProcessoExists(Guid id)
        {
            return _context.Processos.Any(e => e.Id == id);
        }
    }
}
