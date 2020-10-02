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
    public class CursoController : ControllerBase
    {

        private readonly ICursoRepository _cursoRepository;
        public CursoController()
        {
            _cursoRepository = new CursoRepository();
        }

        /// <summary>
        /// Mostrar os cursos cadastrados
        /// </summary>
        /// <returns>Lista de Cursos</returns>
        [HttpGet]
        [Authorize(Roles = "Admin,Padrao")]
        public IActionResult Get()
        {
            try
            {
                var curso = _cursoRepository.Listar();

                if (curso.Count == 0)
                    return NoContent();

                return Ok(curso);
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/curso"
                });
            }
        }   

        /// <summary>
        /// Buscar Curso por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o id do curso escolhido</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Padrao")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Curso curso = _cursoRepository.BuscarPorId(id);
                if (curso == null)
                    return NotFound();

                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastrar um curso
        /// </summary>
        /// <param name="curso"></param>
        /// <returns>curso</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(Curso curso)
        {
            try
            {
                _cursoRepository.Adicionar(curso);

                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Modificar um determinado curso
        /// </summary>
        /// <param name="id"></param>
        /// <param name="curso"></param>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(Guid id, Curso curso)
        {
            try
            {
                _cursoRepository.Editar(curso);

                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Excluir derterminado id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var curso = _cursoRepository.BuscarPorId(id);

                _cursoRepository.Excluir(id);

                if (curso == null)
                    return NotFound();

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
