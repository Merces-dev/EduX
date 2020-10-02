using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly EduXContext _context;

        public UsuarioController(EduXContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        /// <summary>
        /// Mostra todos os usuários cadastrados
        /// </summary>
        /// <returns>Lista com todos os usuários</returns>

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/Usuario/5
        /// <summary>
        /// Mostra um único usuário
        /// </summary>
        /// <param name="id">Id do usuario</param>
        /// <returns>Um usuario</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Usuario>> GetUsuario(Guid id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Altera determinado usuario   
        /// </summary>
        /// <param name="id">Id do usuario</param>
        /// <param name="usuario">Objeto do usuario com alterações</param>
        /// <returns>usuario alterado</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutUsuario(Guid id, Usuario usuario)
        {


            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            //Criptografa a senha e define o salt como os 3 primeiros caracteres do email
            usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 3));

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="usuario">Objeto completo de usuario</param>
        /// <returns>usuario cadastrado</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {

            //Criptografa a senha e define o salt como os 3 primeiros caracteres do email
            usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 3));

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
        }

        // DELETE: api/Usuario/5
        /// <summary>
        /// Exclui um usuario
        /// </summary>
        /// <param name="id">Id do usuario</param>
        /// <returns>Id usuario</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(Guid id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(Guid id)
        {
            return _context.Usuario.Any(e => e.IdUsuario == id);
        }
    }
}
