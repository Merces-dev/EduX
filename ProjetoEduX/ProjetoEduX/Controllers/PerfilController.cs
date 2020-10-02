using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;

namespace ProjetoEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilRepository _perfilRepository;
        
        public PerfilController()
        {
            _perfilRepository = new PerfilRepository();
        }


        /// <summary>
        /// Mostra todos os perfils cadastrados
        /// </summary>
        /// <returns>Lista com todos os perfils</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var perfil = _perfilRepository.Listar();

                if (perfil.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = perfil.Count,
                    data = perfil

                });
            }
            catch (Exception)
            {

                return BadRequest(new
                {
                    StatusCode = 400,
                    error = "Ocoorreu um erro no endpoint Get/perfil, envie um e-mail para x@gmail.com"
                });
            }
        }

        // GET api/perfil/5
        /// <summary>
        /// Mostra um único perfil
        /// </summary>
        /// <param name="id">Id do perfil</param>
        /// <returns>Um perfil</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Perfil perfil = _perfilRepository.BuscarPorId(id);
                if (perfil == null)
                    return NotFound();

                return Ok(perfil);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/perfil
        /// <summary>
        /// Cadastra um perfil
        /// </summary>
        /// <param name="perfil">Objeto completo de perfil</param>
        /// <returns>perfil cadastrado</returns>
        [HttpPost]

        public IActionResult Post(Perfil perfil)
        {
            try
            {

                _perfilRepository.Adicionar(perfil);

                return Ok(perfil);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        // PUT api/perfil/5
        /// <summary>
        /// Altera determinado perfil   
        /// </summary>
        /// <param name="id">Id do perfil</param>
        /// <param name="perfil">Objeto do perfil com alterações</param>
        /// <returns>perfil alterado</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(Guid id, Perfil perfil)
        {
            try
            {
                _perfilRepository.Editar(perfil);

                return Ok(perfil);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/perfil/5
        /// <summary>
        /// Exclui um perfil
        /// </summary>
        /// <param name="id">Id do perfil</param>
        /// <returns>Id excluido</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var perfil = _perfilRepository.BuscarPorId(id);

                if (perfil == null)
                    return NotFound();

                _perfilRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
