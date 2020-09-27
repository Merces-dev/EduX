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
