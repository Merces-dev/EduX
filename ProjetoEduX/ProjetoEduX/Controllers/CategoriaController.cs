using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;

namespace ProjetoEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        
        private readonly EduXContext _context;

        public CategoriaController(EduXContext context)
        {
            _context = context;
        }


        // GET: api/Categoria
        /// <summary>
        /// Mostra todas as categorias cadastradas
        /// </summary>
        /// <returns>Lista com todas as categorias</returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {
            return await _context.Categoria.ToListAsync();
        }

        // GET: api/Categoria/5
        /// <summary>
        /// Mostra uma única categoria 
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <returns>Uma categoria</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Categoria>> GetCategoria(Guid id)
        {
            var categoria = await _context.Categoria.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categoria/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        /// <summary>
        /// Altera determinada categoria
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <param name="categoria">Objeto de categoria com alterações</param>
        /// <returns>categoria alterada</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutCategoria(Guid id, Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

        // POST: api/Categoria
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        /// <summary>
        /// Cadastra uma categoria
        /// </summary>
        /// <param name="categoria">Objeto completo de categoria</param>
        /// <returns>categoria cadastrada</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.IdCategoria }, categoria);
        }

        // DELETE: api/Categoria/5

        /// <summary>
        /// Exclui uma categoria
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <returns>Id excluido</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Categoria>> DeleteCategoria(Guid id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        private bool CategoriaExists(Guid id)
        {
            return _context.Categoria.Any(e => e.IdCategoria == id);
        }
    }
}
