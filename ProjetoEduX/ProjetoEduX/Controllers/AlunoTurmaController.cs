using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Repositories;

namespace ProjetoEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoTurmaController : ControllerBase
    {
        private readonly AlunoTurmaRepository _alunoTurmaRepository;

        public AlunoTurmaController()
        {
            _alunoTurmaRepository = new AlunoTurmaRepository();
        }

        // GET: api/AlunoTurma
        /// <summary>
        /// Mostra todos os AlunoTurmas cadastrados
        /// </summary>
        /// <returns>Lista com todos os AlunoTurmas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var alunosturmas = _alunoTurmaRepository.Listar();

                if (alunosturmas.Count == 0)
                    return NoContent();

                return Ok(alunosturmas);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET: api/AlunoTurma/5
        /// <summary>
        /// Mostra um único AlunoTurma
        /// </summary>
        /// <param name="id">Id do AlunoTurma</param>
        /// <returns>Um AlunoTurma</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                AlunoTurma alunoTurma = _alunoTurmaRepository.BuscarPorId(id);

                if (alunoTurma == null)
                    return NotFound();

                return Ok(alunoTurma);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/AlunoTurma/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Altera determinado AlunoTurma 
        /// </summary>
        /// <param name="id">Id do AlunoTurma</param>
        /// <param name="alunoTurma">Objeto do alunoturma com alterações</param>
        /// <returns>alunoTurma alterado</returns>

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, AlunoTurma alunoTurma)
        {
            try
            {
                _alunoTurmaRepository.Editar(alunoTurma);

                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/AlunoTurma
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Cadastra um AlunoTurma
        /// </summary>
        /// <param name="alunoTurma">Objeto completo de AlunoTurma</param>
        /// <returns>perfil AlunoTurma</returns>
        [HttpPost]
        public IActionResult Post([FromForm] AlunoTurma alunoTurma)
        {
            try
            {
                _alunoTurmaRepository.Adicionar(alunoTurma);


                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/AlunoTurma/5
        /// <summary>
        /// Exclui um AlunoTurma
        /// </summary>
        /// <param name="id">Id do AlunoTurma</param>
        /// <returns>Id excluido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                var alunoTurma = _alunoTurmaRepository.BuscarPorId(id);


                if (alunoTurma == null)
                    return NotFound();


                _alunoTurmaRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
