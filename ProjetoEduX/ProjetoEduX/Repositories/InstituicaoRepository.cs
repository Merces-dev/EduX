using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {

        private EduXContext _ctx;
        public InstituicaoRepository()
        {
            _ctx = new EduXContext();
        }

        /// <summary>
        /// Cria uma instituicao
        /// </summary>
        /// <param name="instituicao">Instituicao a ser criada</param>
        public void Adicionar(Instituicao instituicao)
        {
            try
            {

                _ctx.Instituicao.Add(instituicao);


                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma instituicao pelo Id
        /// </summary>
        /// <param name="id">Id da instituicao</param>
        /// <returns>instituicao</returns>
        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Instituicao.FirstOrDefault(c => c.IdInstituicao == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// edita uma instituicao ja existente
        /// </summary>
        /// <param name="instituicao">instituicao a ser editada</param>
        public void Editar(Instituicao instituicao)
        {
            try
            {

                Instituicao instituicaoTemp = BuscarPorId(instituicao.IdInstituicao);


                if (instituicaoTemp == null)
                    throw new Exception("Instituição não encontrada");

                //Caso exista, fará a alteração
                instituicaoTemp.Nome = instituicao.Nome;
                instituicaoTemp.Logradouro = instituicao.Logradouro;
                instituicaoTemp.Numero = instituicao.Numero;
                instituicaoTemp.Bairro = instituicao.Bairro;
                instituicaoTemp.Cidade = instituicao.Cidade;
                instituicaoTemp.Complemento = instituicao.Complemento;
                instituicaoTemp.Cep = instituicao.Cep;
                instituicaoTemp.Uf = instituicao.Uf;


                _ctx.Instituicao.Update(instituicaoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista as instituicoes ja criadas
        /// </summary>
        /// <returns>lista de instituicoes</returns>
        public List<Instituicao> Listar()
        {
            try
            {
                return _ctx.Instituicao.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// remove uma instituicao pelo seu id
        /// </summary>
        /// <param name="id">id da instituicao</param>
        public void Remover(Guid id)
        {
            try
            {

                Instituicao instituicaoTemp = BuscarPorId(id);

                if (instituicaoTemp == null)
                    throw new Exception("Instituicao não encontrada");


                _ctx.Instituicao.Remove(instituicaoTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
