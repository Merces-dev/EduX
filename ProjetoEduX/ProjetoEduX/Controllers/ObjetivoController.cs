using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using ProjetoEduX.Repositories;

namespace ProjetoEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetivoController : ControllerBase
    {
        private readonly IObjetivoRepository _objetivoRepository;

        public ObjetivoController()
        {
            _objetivoRepository = new ObjetivoRepository();
        }

        // GET: api/Objetivo
        /// <summary>
        /// Mostra todos os Objetivos cadastrados
        /// </summary>
        /// <returns>Lista com todos os objetivos</returns>
        [HttpGet]
        [Authorize(Roles = "Admin,Padrao")]
        public IActionResult Get()
        {
            try
            {
                var objetivos = _objetivoRepository.Listar();

                if (objetivos.Count == 0)
                    return NoContent();

                return Ok(objetivos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Objetivo/5
        /// <summary>
        /// Mostra um único objetivo
        /// </summary>
        /// <param name="id">Id do Objetivo</param>
        /// <returns>Um Objetivo</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Padrao")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Objetivo objetivo = _objetivoRepository.BuscarPorId(id);

                if (objetivo == null)
                    return NotFound();

                return Ok(objetivo);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Objetivo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Altera determinado objetivo
        /// </summary>
        /// <param name="id">Id do Objetivo</param>
        /// <param name="objetivo">Objeto de objetivo com alterações</param>
        /// <returns> Objetivo alterado</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(Guid id, Objetivo objetivo)
        {
            try
            {
                _objetivoRepository.Editar(objetivo);

                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Objetivo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Cadastra um Objetivo
        /// </summary>
        /// <param name="objetivo">Objeto completo de Objetivo</param>
        /// <returns>Objetivo cadastrado</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromForm] Objetivo objetivo)
        {
            try
            {
                _objetivoRepository.Adicionar(objetivo);


                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Objetivo/5
        /// <summary>
        /// Exclui um objetivo
        /// </summary>
        /// <param name="id">Id do objetivo</param>
        /// <returns>Id excluido</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                var objetivo = _objetivoRepository.BuscarPorId(id);


                if (objetivo == null)
                    return NotFound();


                _objetivoRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
