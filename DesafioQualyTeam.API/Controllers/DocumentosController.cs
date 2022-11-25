using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioQualyTeam.API.Data;
using DesafioQualyTeam.API.Entities;
using System.Net.Http.Headers;

namespace DesafioQualyTeam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DocumentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Documentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documento>>> GetDocumentos()
        {
            return await _context.Documentos
                .Include(e => e.Processo)
                .OrderBy(e => e.Titulo)
                .AsNoTracking()
                .ToListAsync();
        }

        // GET: api/Documentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Documento>> GetDocumento(Guid id)
        {
            var documento = await _context.Documentos
                .Include(e => e.DetalheArquivo)
                .Include(e => e.Processo)
                .SingleOrDefaultAsync(e => e.Id == id);

            if (documento == null)
            {
                return NotFound();
            }

            return documento;
        }

        // PUT: api/Documentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), DisableRequestSizeLimit]
        public async Task<IActionResult> PutDocumento(Guid id, [FromForm] Documento documento)
        {
            if (id != documento.Id)
            {
                return BadRequest();
            }

            _context.Entry(documento).State = EntityState.Modified;
            _context.Entry(documento).Reference(e => e.DetalheArquivo).Load();
            _context.Entry(documento.DetalheArquivo).Reference(e => e.Arquivo).Load();

            var file = Request.Form.Files.FirstOrDefault(defaultValue: null);
            if (file?.Length > 0)
            {
                documento.DetalheArquivo.Nome = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                documento.DetalheArquivo.ContentType = file.ContentType;

                if (!DocumentoUtils.TiposArquivoAceitos.Contains(documento.DetalheArquivo.ContentType))
                {
                    return BadRequest();
                }

                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    documento.DetalheArquivo.Arquivo.Dados = stream.ToArray();
                }
            }

            try
            {
                await _context.SaveChangesAsync();
                _context.Entry(documento).Reference(e => e.Processo).Load();
                documento.DetalheArquivo.Arquivo = null;
                return Ok(documento);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentoExists(id))
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

        // POST: api/Documentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<Documento>> PostDocumento([FromForm] Documento documento)
        {
            try
            {
                var file = Request.Form.Files.FirstOrDefault(defaultValue: null);
                if (file?.Length <= 0)
                {
                    return BadRequest();
                }

                documento.DetalheArquivo = new()
                {
                    Nome = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"'),
                    ContentType = file.ContentType
                };

                if (!DocumentoUtils.TiposArquivoAceitos.Contains(documento.DetalheArquivo.ContentType))
                {
                    return BadRequest();
                }

                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    documento.DetalheArquivo.Arquivo = new() { Dados = stream.ToArray() };
                }

                _context.Documentos.Add(documento);
                await _context.SaveChangesAsync();

                documento.DetalheArquivo.Arquivo = null;

                return CreatedAtAction("GetDocumento", new { id = documento.Id }, documento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        // DELETE: api/Documentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumento(Guid id)
        {
            var documento = await _context.Documentos.FindAsync(id);

            if (documento == null)
            {
                return NotFound();
            }

            _context.Documentos.Remove(documento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Documentos/5/DownloadArquivo
        [HttpGet("{id}/DownloadArquivo")]
        public async Task<ActionResult<Documento>> DownloadArquivo(Guid id)
        {
            var documento = await _context.Documentos
                .Include(e => e.DetalheArquivo)
                    .ThenInclude(e => e.Arquivo)
                .SingleOrDefaultAsync(e => e.Id == id);

            if (documento == null)
            {
                return NotFound();
            }

            var arquivo = documento.DetalheArquivo?.Arquivo?.Dados;

            if (arquivo == null)
                return StatusCode(500, $"Internal server error.");

            var memory = new MemoryStream(arquivo);
            var contentType = documento.DetalheArquivo?.ContentType ?? "application/octet-stream";

            return File(memory, contentType);
        }

        private bool DocumentoExists(Guid id)
        {
            return _context.Documentos.Any(e => e.Id == id);
        }
    }
}
