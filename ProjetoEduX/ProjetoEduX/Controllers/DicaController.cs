using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEduX.Domains;
using ProjetoEduX.Repositories;
using ProjetoEduX.Utils;

namespace ProjetoEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicaController : ControllerBase
    {
        private readonly DicaRepository _dicaRepository;

        public DicaController()
        {
            _dicaRepository = new DicaRepository();
        }

        // GET: api/Dica
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var dicas = _dicaRepository.Listar();

                if (dicas.Count == 0)
                    return NoContent();

                return Ok(dicas);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET: api/Dica/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Dica dica = _dicaRepository.BuscarPorId(id);

                if (dica == null)
                    return NotFound();

                return Ok(dica);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Dica/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Dica dica)
        {
            try
            {
                //Edita a instituicao
                _dicaRepository.Editar(dica);

                //Retorna Ok com os dados da instituicao
                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Dica
        [HttpPost]
        public IActionResult Post([FromForm] Dica dica)
        {

            try
            {
          
                if (dica.Imagem != null)
                {
                    var urlImagem = Upload.Local(dica.Imagem);

                    dica.UrlImagem = urlImagem;

                }

                //Adiciona uma dica
                _dicaRepository.Adicionar(dica);

                //retorna ok com os dados da dica
                return Ok(dica);
            }
            catch (Exception ex)
            {
                //caso ocorra erro retorna um Bad Request e mensagem do erro
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Dica/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                var dica = _dicaRepository.BuscarPorId(id);


                if (dica == null)
                    return NotFound();


                _dicaRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}