using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Utils;

namespace ProjetoEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicaController : ControllerBase
    {
        private EduXContext _context = new EduXContext();

        // GET: api/Dica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dica>>> GetDica()
        {
            return await _context.Dica.ToListAsync();
        }

        // GET: api/Dica/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dica>> GetDica(Guid id)
        {
            var dica = await _context.Dica.FindAsync(id);

            if (dica == null)
            {
                return NotFound();
            }

            return dica;
        }

        // PUT: api/Dica/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDica(Guid id, Dica dica)
        {
            if (id != dica.IdDica)
            {
                return BadRequest();
            }

            _context.Entry(dica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DicaExists(id))
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

        // POST: api/Dica
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Dica>> PostDica(Dica dica)
        {
            try
            {

                if (dica.Imagem != null)
                {
                    var urlImagem = Upload.Local(dica.Imagem);

                    dica.UrlImagem = urlImagem;
                }

                _context.Dica.Add(dica);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetDica", new { id = dica.IdDica }, dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Dica/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dica>> DeleteDica(Guid id)
        {
            var dica = await _context.Dica.FindAsync(id);
            if (dica == null)
            {
                return NotFound();
            }

            _context.Dica.Remove(dica);
            await _context.SaveChangesAsync();

            return dica;
        }

        private bool DicaExists(Guid id)
        {
            return _context.Dica.Any(e => e.IdDica == id);
        }
    }
}
