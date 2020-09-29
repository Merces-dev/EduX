using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoEduX.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly EduXContext _ctx;
        public TurmaRepository()
        {
            _ctx = new EduXContext();
        }

        public void Adicionar(Turma turma)
        {
            try
            {
                _ctx.Turma.Add(turma);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Turma BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Turma.FirstOrDefault(c => c.IdCurso == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Turma turma)
        {
            try
            {
                Turma turma1 = BuscarPorId(turma.IdTurma);
                if (turma1 == null)
                    throw new Exception("Turma não encontarada");

                turma1.Descricao = turma.Descricao;

                _ctx.Turma.Update(turma1);
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
                Turma turma1 = BuscarPorId(id);
                if (turma1 == null)
                    throw new Exception("Turma não encontarada");

                _ctx.Turma.Remove(turma1);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Turma> Listar()
        {
            try
            {
                return _ctx.Turma.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
