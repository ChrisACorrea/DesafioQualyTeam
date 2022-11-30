using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioQualyTeam.API.Data;
using DesafioQualyTeam.API.Entities;

namespace DesafioQualyTeam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias
                .Include(e => e.Processo)
                .OrderBy(e => e.Nome).ToListAsync();
        }

        [HttpGet("byProcesso")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriasByProcesso([FromQuery] string processoId)
        {
            if (string.IsNullOrWhiteSpace(processoId) || processoId.Equals("undefined", StringComparison.InvariantCultureIgnoreCase))
                return BadRequest();

            return await _context.Categorias
                .Where(e => e.ProcessoId == new Guid(processoId))
                .OrderBy(e => e.Nome).ToListAsync();
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(Guid id)
        {
            var categoria = await _context.Categorias
                .Include(e => e.Processo)
                .FirstOrDefaultAsync();

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(Guid id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(categoria);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        // POST: api/Categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            categoria.Processo = null;
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(Guid id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(Guid id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
