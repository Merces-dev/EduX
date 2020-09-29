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
    public class ObjetivoController : ControllerBase
    {
        private EduXContext _context = new EduXContext();

        // GET: api/Objetivo
        [HttpGet]
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
        [HttpGet("{id}")]
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
        [HttpPut("{id}")]
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
        [HttpPost]
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
        [HttpDelete("{id}")]
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
