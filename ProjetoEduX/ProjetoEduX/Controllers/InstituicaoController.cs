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
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        // GET: api/Instituicao
        /// <summary>
        /// Mostra todas as instuições cadastradas
        /// </summary>
        /// <returns>Lista com todas as instituições</returns>
        [HttpGet]
       

        public IActionResult Get()
        {
            try
            {

                var instituicoes = _instituicaoRepository.Listar();

                if (instituicoes.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = instituicoes.Count,
                    data = instituicoes

                });

                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET: api/Instituicao/5
        /// <summary>
        /// Mostra uma única instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <returns>Uma instituição</returns>
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

        /// <summary>
        /// Altera determinada instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <param name="instituicao">Objeto de instituição com alterações</param>
        /// <returns> instituição alterada</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
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

        /// <summary>
        /// Cadastra uma insituição
        /// </summary>
        /// <param name="instituicao">Objeto completo de instituição</param>
        /// <returns>instituição cadastrada</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        /// <summary>
        /// Exclui uma instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <returns>Id excluido</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
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
