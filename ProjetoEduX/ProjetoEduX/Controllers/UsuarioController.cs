using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoEduX.Domains;
using ProjetoEduX.Repositories;
using ProjetoEduX.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        // GET: api/<UsuarioController>
        [HttpGet]
        
        
        public IActionResult Get()
        {
            try
            {

                var usuario = _usuarioRepository.Listar();

                if (usuario.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = usuario.Count,
                    data = usuario

                });


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Usuario usuario = _usuarioRepository.BuscarPorId(id);

                if (usuario == null)
                    return NotFound();

                return Ok(usuario);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Put(Guid id, Usuario usuario)
        {

            //Criptografa a senha e define o salt com os 3 primeiros digitos do email
            usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 3));

            try
            {
                //Edita o usuario
                _usuarioRepository.Editar(usuario);

                //Retorna Ok com os dados do usuario
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IActionResult Post(Usuario usuario)
        {

            //Criptografa a senha e define o salt com os 3 primeiros digitos do email
            usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 3));


            try
            {
                _usuarioRepository.Adicionar(usuario);


                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                var usuario = _usuarioRepository.BuscarPorId(id);


                if (usuario == null)
                    return NotFound();


                _usuarioRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
