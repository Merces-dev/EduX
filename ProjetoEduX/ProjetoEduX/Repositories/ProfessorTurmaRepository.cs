using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class ProfessorTurmaRepository : IProfessorTurmaRepository
    {
        private EduXContext _ctx = new EduXContext();

        public void Adicionar(ProfessorTurma professorturma)
        {
            try
            {

                _ctx.Set<ProfessorTurma>().Add(professorturma);


                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ProfessorTurma BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.ProfessorTurma.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Editar(ProfessorTurma professorturma)
        {
            try
            {

                ProfessorTurma professorTurmaTemp = BuscarPorId(professorturma.IdProfessorUsuario);


                if (professorTurmaTemp == null)
                    throw new Exception("Professor não foi encontrado");

                //Caso exista, fará a alteração	
                professorTurmaTemp.Descricao = professorturma.Descricao;
                professorTurmaTemp.IdUsuario = professorturma.IdUsuario;
                professorTurmaTemp.IdTurma = professorturma.IdTurma;

                _ctx.ProfessorTurma.Update(professorTurmaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<ProfessorTurma> Listar()
        {
            try
            {
                return _ctx.ProfessorTurma.ToList();
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
                ProfessorTurma professorTurmaTemp = BuscarPorId(id);
                _ctx.ProfessorTurma.Remove(professorTurmaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
