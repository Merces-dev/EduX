using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly EduXContext _ctx;
        public CursoRepository()
        {
            _ctx = new EduXContext();
        }

        public void Adicionar(Curso curso)
        {
            try
            {
                _ctx.Curso.Add(curso);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Curso BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Curso.FirstOrDefault(c => c.IdCurso == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Curso curso)
        {
            try
            {
                Curso curso1 = BuscarPorId(curso.IdCurso);
                if (curso1 == null)
                    throw new Exception("Curso não encontrado");

                curso1.Titulo = curso.Titulo;

                _ctx.Curso.Update(curso1);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                Curso curso1 = BuscarPorId(id);
                if (curso1 == null)
                    throw new Exception("Curso não encontrado");


                _ctx.Curso.Remove(curso1);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Curso> Listar()
        {
            try
            {
                return _ctx.Curso.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}