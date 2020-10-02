using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        private readonly EduXContext _context;

        public DicaController(EduXContext context)
        {
            _context = context;
        }
       
        // GET: api/Dica
        /// <summary>
        /// Mostra todas as dicas cadastradas
        /// </summary>
        /// <returns>Lista com todas as dicas</returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Dica>>> GetDica()
        {
            return await _context.Dica.ToListAsync();
        }

        // GET: api/Dica/5
        /// <summary>
        /// Mostra uma única dica
        /// </summary>
        /// <param name="id">Id da dica</param>
        /// <returns>Uma dica</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
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

        /// <summary>
        /// Altera determinada dica
        /// </summary>
        /// <param name="id">Id da dica</param>
        /// <param name="dica">Objeto de dica com alterações</param>
        /// <returns> dica alterada</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
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

        /// <summary>
        /// Cadastra uma dica
        /// </summary>
        /// <param name="dica">Objeto completo de dica</param>
        /// <returns>dica cadastrada</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Dica>> PostDica([FromForm] Dica dica)
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

                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Dica/5

        /// <summary>
        /// Exclui uma dica
        /// </summary>
        /// <param name="id">Id da dica</param>
        /// <returns>Id excluido</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
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
