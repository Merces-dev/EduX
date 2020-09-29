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
    public class ObjetivoAlunoController : ControllerBase
    {
        private EduXContext _context = new EduXContext();

        // GET: api/ObjetivoAluno
        [HttpGet]
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
        [HttpGet("{id}")]
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
        [HttpPut("{id}")]
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
        [HttpPost]
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
        [HttpDelete("{id}")]
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