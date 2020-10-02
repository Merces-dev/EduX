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
    public class ProfessorTurmaController : ControllerBase
    {
        private readonly IProfessorTurmaRepository _professorTurmaRepository;

        public ProfessorTurmaController()
        {
            _professorTurmaRepository = new ProfessorTurmaRepository();
        }


        // GET: api/ProfessorTurma
        /// <summary>
        /// Mostra todos os ProfessorTurmas cadastrados
        /// </summary>
        /// <returns>Lista com todos os ProfessorTurmas</returns>
        [HttpGet]
        [Authorize(Roles = "Admin,Padrao")]
        public IActionResult Get()
        {
            try
            {

                var professoresturmas = _professorTurmaRepository.Listar();

                if (professoresturmas.Count == 0)
                    return NoContent();

                return Ok(professoresturmas);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET: api/ProfessorTurma/5
        /// <summary>
        /// Mostra um único ProfessorTurma
        /// </summary>
        /// <param name="id">Id do ProfessorTurma</param>
        /// <returns>Um ProfessorTurma</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Padrao")]
        public IActionResult Get(Guid id)
        {
            try
            {
                ProfessorTurma professorTurma = _professorTurmaRepository.BuscarPorId(id);

                if (professorTurma == null)
                    return NotFound();

                return Ok(professorTurma);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/ProfessorTurma/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Altera determinado ProfessorTurma
        /// </summary>
        /// <param name="id">Id do ProfessorTurma</param>
        /// <param name="professorTurma">Objeto de ProfessorTurma com alterações</param>
        /// <returns> ProfessorTurma alterado</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(Guid id, ProfessorTurma professorTurma)
        {
            try
            {
                _professorTurmaRepository.Editar(professorTurma);

                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/ProfessorTurma
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra um ProfessorTurma
        /// </summary>
        /// <param name="professorTurma">Objeto completo de ProfessorTurma</param>
        /// <returns>ProfessorTurma cadastrado</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromForm] ProfessorTurma professorTurma)
        {
            try
            {
                _professorTurmaRepository.Adicionar(professorTurma);


                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ProfessorTurma/5
        /// <summary>
        /// Exclui um ProfessorTurma
        /// </summary>
        /// <param name="id">Id do ProfessorTurma</param>
        /// <returns>Id excluido</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                var professorTurma = _professorTurmaRepository.BuscarPorId(id);


                if (professorTurma == null)
                    return NotFound();


                _professorTurmaRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}