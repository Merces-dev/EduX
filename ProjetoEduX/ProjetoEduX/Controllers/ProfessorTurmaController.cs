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
    public class ProfessorTurmaController : ControllerBase
    {
        private readonly ProfessorTurmaRepository _professorTurmaRepository;

        public ProfessorTurmaController()
        {
            _professorTurmaRepository = new ProfessorTurmaRepository();
        }

        // GET: api/ProfessorTurma
        [HttpGet]
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
        [HttpGet("{id}")]
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
        [HttpPut("{id}")]
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
        [HttpPost]
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
        [HttpDelete("{id}")]
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
