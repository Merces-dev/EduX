using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class DicaRepository : IDicaRepository
    {

        private readonly EduXContext _ctx;
        public DicaRepository()
        {
            _ctx = new EduXContext();
        }

        #region Leitura


        /// <summary>
        /// Busca uma dica pelo Id
        /// </summary>
        /// <param name="id">Id da dica</param>
        /// <returns>dica</returns>
        public Dica BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Dica.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista as dicas que já foram criadas
        /// </summary>
        /// <returns>dicas</returns>
        public List<Dica> Listar()
        {
            try
            {
                return _ctx.Dica.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Gravação

        /// <summary>
        /// Cria uma dica
        /// </summary>
        /// <param name="dica">Cria uma dica</param>
        public void Adicionar(Dica dica)
        {
            try
            {
                _ctx.Dica.Add(dica);

                //Salvando alterações do contexto
                _ctx.SaveChanges();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Edita uma dica
        /// </summary>
        /// <param name="dica">dica que será editada</param>
        public void Editar(Dica dica)
        {
            try
            {
                Dica dicaTemp = BuscarPorId(dica.IdDica);


                if (dicaTemp == null)
                    throw new Exception("Dica não encontrada");

                //Caso exista, fará a alteração
                dicaTemp.Texto = dica.Texto;
                dicaTemp.Imagem = dica.Imagem;

                _ctx.Dica.Update(dicaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// remove uma dica pelo seu id
        /// </summary>
        /// <param name="id">id da dica</param>
        public void Remover(Guid id)
        {
            try
            {
                Dica dicaTemp = BuscarPorId(id);

                _ctx.Dica.Remove(dicaTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
