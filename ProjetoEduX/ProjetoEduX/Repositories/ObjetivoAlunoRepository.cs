using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class ObjetivoAlunoRepository : IObjetivoAlunoRepository
    {
        private EduXContext _ctx = new EduXContext();

        #region Gravacao
        public void Adicionar(ObjetivoAluno objetivoaluno)
        {
            try
            {
                _ctx.Set<ObjetivoAluno>().Add(objetivoaluno);

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
                ObjetivoAluno objetivoAlunoTemp = BuscarPorId(id);
                _ctx.ObjetivoAluno.Remove(objetivoAlunoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Editar(ObjetivoAluno objetivoaluno)
        {
            try
            {
                ObjetivoAluno objetivoAlunoTemp = BuscarPorId(objetivoaluno.IdObjetivoAluno);
                if (objetivoAlunoTemp == null)
                    throw new Exception("ObjetivoAluno não encontrado");
                objetivoAlunoTemp.Nota = objetivoaluno.Nota;
                objetivoAlunoTemp.DataAlcancado = objetivoaluno.DataAlcancado;
                objetivoAlunoTemp.IdAlunoTurma = objetivoaluno.IdAlunoTurma;
                objetivoAlunoTemp.IdObjetivo = objetivoaluno.IdObjetivo;

                _ctx.ObjetivoAluno.Update(objetivoAlunoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region Leitura

        public List<ObjetivoAluno> Listar()
        {
            try
            {
                return _ctx.ObjetivoAluno.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ObjetivoAluno BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.ObjetivoAluno.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
