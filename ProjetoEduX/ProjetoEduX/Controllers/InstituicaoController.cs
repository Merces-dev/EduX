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
    public class InstituicaoController : ControllerBase
    {
        private readonly InstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        // GET: api/Instituicao
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                var instituicao = _instituicaoRepository.Listar();

                if (instituicao.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = instituicao.Count,
                    data = instituicao

                });

                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET: api/Instituicao/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Instituicao instituicao = _instituicaoRepository.BuscarPorId(id);

                if (instituicao == null)
                    return NotFound();

                return Ok(instituicao);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Instituicao/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Instituicao instituicao)
        {
            try
            {
                //Edita a instituicao
                _instituicaoRepository.Editar(instituicao);

                //Retorna Ok com os dados da instituicao
                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Instituicao
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {

            

            try
            {
                _instituicaoRepository.Adicionar(instituicao);


                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Instituicao/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                var instituicao = _instituicaoRepository.BuscarPorId(id);


                if (instituicao == null)
                    return NotFound();


                _instituicaoRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
