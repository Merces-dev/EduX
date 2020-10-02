using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using ProjetoEduX.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaController()
        {
            _turmaRepository = new TurmaRepository();
        }

        /// <summary>
        /// Mostar todos as turmas cadastradas
        /// </summary>
        /// <returns>Lista com as Turmas</returns>
        ///
        [HttpGet]
        [Authorize(Roles = "Admin,Padrao")]
        public IActionResult Get()
        {
            try
            {
                var turma = _turmaRepository.Listar();

                if (turma.Count == 0)
                    return NoContent();

                return Ok(turma);
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/turma"
                });
            }
        }

        /// <summary>
        /// Buscar por determinado Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o Id da turma escolhida</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Padrao")]
        public IActionResult Get(Guid id)
        {
           try
            {
               Turma turma = _turmaRepository.BuscarPorId(id);
                if (turma == null)
                    return NotFound();

                return Ok(turma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar Turma
        /// </summary>
        /// <param name="turma"></param>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post (Turma turma)
        {
            try
            {
                _turmaRepository.Adicionar(turma);

                return Ok(turma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Modificar Turma
        /// </summary>
        /// <param name="id"></param>
        /// <param name="turma"></param>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(Guid id, Turma turma)
        {
            try
            {
                _turmaRepository.Editar(turma);

                return Ok(turma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletar determinada Turma
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var turma = _turmaRepository.BuscarPorId(id);

                if (turma == null)
                    return NotFound();

                _turmaRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
