using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class ObjetivoRepository : IObjetivoRepository
    {
        private EduXContext _ctx = new EduXContext();
        #region Gravacao
        public void Adicionar(Objetivo objetivo)
        {
            try
            {
                _ctx.Set<Objetivo>().Add(objetivo);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Remover(Guid id)
        {
            try
            {
                 Objetivo objetivoTemp = BuscarPorId(id);
                _ctx.Objetivo.Remove(objetivoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Editar(Objetivo objetivo)
        {
            try
            {
                Objetivo objetivoTemp =  BuscarPorId(objetivo.IdObjetivo);
                if (objetivoTemp == null)
                    throw new Exception("Objetivo não encontrado");
                objetivoTemp.Descricao = objetivo.Descricao;
                objetivoTemp.IdCategoria = objetivo.IdCategoria;

                _ctx.Objetivo.Update(objetivoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    
        #endregion
        #region Leitura
        public List<Objetivo> Listar()
        {
            try
            {
                return _ctx.Objetivo.ToList();
            }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
  
}
        public Objetivo BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Objetivo.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }        
        #endregion
    }
}
