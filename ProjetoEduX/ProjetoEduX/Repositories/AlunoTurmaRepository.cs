using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduXGrupo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class AlunoTurmaRepository : IAlunoTurmaRepository
    {
        private EduXContext _ctx = new EduXContext();
        #region Gravacao

        public void Adicionar(AlunoTurma alunoturma)
        {
            try
            {

                _ctx.Set<AlunoTurma>().Add(alunoturma);


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
                AlunoTurma alunoTurmaTemp = BuscarPorId(id);
                _ctx.AlunoTurma.Remove(alunoTurmaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
       

        public void Editar(AlunoTurma alunoturma)
        {
            try
            {

                AlunoTurma alunoTurmaTemp = BuscarPorId(alunoturma.IdAlunoTurma);


                if (alunoTurmaTemp == null)
                    throw new Exception("Aluno não foi encontrado");

                //Caso exista, fará a alteração	
                alunoTurmaTemp.Matricula = alunoturma.Matricula;
                alunoTurmaTemp.IdUsuario = alunoturma.IdUsuario;
                alunoTurmaTemp.IdTurma   = alunoturma.IdTurma;

                _ctx.AlunoTurma.Update(alunoTurmaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region leitura
        public List<AlunoTurma> Listar()
        {
            try
            {
                return _ctx.AlunoTurma.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public AlunoTurma BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.AlunoTurma.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
