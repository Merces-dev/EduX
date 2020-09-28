using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;

namespace ProjetoEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetivoAlunoController : ControllerBase
    {
        private readonly EduXContext _context;

        public ObjetivoAlunoController(EduXContext context)
        {
            _context = context;
        }

        // GET: api/ObjetivoAluno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjetivoAluno>>> GetObjetivoAluno()
        {
            return await _context.ObjetivoAluno.ToListAsync();
        }

        // GET: api/ObjetivoAluno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjetivoAluno>> GetObjetivoAluno(Guid id)
        {
            var objetivoAluno = await _context.ObjetivoAluno.FindAsync(id);

            if (objetivoAluno == null)
            {
                return NotFound();
            }

            return objetivoAluno;
        }

        // PUT: api/ObjetivoAluno/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjetivoAluno(Guid id, ObjetivoAluno objetivoAluno)
        {
            if (id != objetivoAluno.IdObjetivoAluno)
            {
                return BadRequest();
            }

            _context.Entry(objetivoAluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjetivoAlunoExists(id))
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

        // POST: api/ObjetivoAluno
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ObjetivoAluno>> PostObjetivoAluno(ObjetivoAluno objetivoAluno)
        {
            _context.ObjetivoAluno.Add(objetivoAluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjetivoAluno", new { id = objetivoAluno.IdObjetivoAluno }, objetivoAluno);
        }

        // DELETE: api/ObjetivoAluno/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ObjetivoAluno>> DeleteObjetivoAluno(Guid id)
        {
            var objetivoAluno = await _context.ObjetivoAluno.FindAsync(id);
            if (objetivoAluno == null)
            {
                return NotFound();
            }

            _context.ObjetivoAluno.Remove(objetivoAluno);
            await _context.SaveChangesAsync();

            return objetivoAluno;
        }

        private bool ObjetivoAlunoExists(Guid id)
        {
            return _context.ObjetivoAluno.Any(e => e.IdObjetivoAluno == id);
        }
    }
}
