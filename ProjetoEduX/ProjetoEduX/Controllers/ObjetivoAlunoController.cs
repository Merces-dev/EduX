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
    public class ObjetivoAlunoController : ControllerBase
    {
        private readonly IObjetivoAlunoRepository _objetivoAlunoRepository;

        public ObjetivoAlunoController()
        {
            _objetivoAlunoRepository = new ObjetivoAlunoRepository();
        }

        // GET: api/ObjetivoAluno
        /// <summary>
        /// Mostra todos os ObjetivoAlunos cadastrados
        /// </summary>
        /// <returns>Lista com todos os objetivoAlunos</returns>
        [HttpGet]
        [Authorize(Roles = "Admin,Padrao")]
        public IActionResult Get()
        {
            try
            {
                var objetivosalunos = _objetivoAlunoRepository.Listar();

                if (objetivosalunos.Count == 0)
                    return NoContent();

                return Ok(objetivosalunos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/ObjetivoAluno/5
        /// <summary>
        /// Mostra um único ObjetivoAluno
        /// </summary>
        /// <param name="id">Id do ObjetivoAluno</param>
        /// <returns>Um ObjetivoAluno</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Padrao")]
        public IActionResult Get(Guid id)
        {
            try
            {
                ObjetivoAluno objetivoaluno = _objetivoAlunoRepository.BuscarPorId(id);

                if (objetivoaluno == null)
                    return NotFound();

                return Ok(objetivoaluno);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/ObjetivoAluno/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Altera determinado ObjetivoAluno
        /// </summary>
        /// <param name="id">Id do ObjtivoAluno</param>
        /// <param name="objetivoaluno">Objeto de objetivoAluno com alterações</param>
        /// <returns> ObjetivoAluno alterada</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(Guid id, ObjetivoAluno objetivoaluno)
        {
            try
            {
                _objetivoAlunoRepository.Editar(objetivoaluno);

                return Ok(objetivoaluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/ObjetivoAluno
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Cadastra um ObjetivoAluno
        /// </summary>
        /// <param name="objetivoaluno">Objeto completo de ObjetivoAluno</param>
        /// <returns>ObjetivoAluno cadastrado</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromForm] ObjetivoAluno objetivoaluno)
        {
            try
            {
                _objetivoAlunoRepository.Adicionar(objetivoaluno);


                return Ok(objetivoaluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ObjetivoAluno/5
        /// <summary>
        /// Exclui um objetivoAluno
        /// </summary>
        /// <param name="id">Id do objetivoAluno</param>
        /// <returns>Id excluido</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                var objetivoaluno = _objetivoAlunoRepository.BuscarPorId(id);


                if (objetivoaluno == null)
                    return NotFound();


                _objetivoAlunoRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}