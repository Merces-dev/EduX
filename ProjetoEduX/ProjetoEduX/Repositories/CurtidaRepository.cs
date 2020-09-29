using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class CurtidaRepository : ICurtidaRepository
    {

        private readonly EduXContext _ctx;
        public CurtidaRepository()
        {
            _ctx = new EduXContext();
        }
        public void Adicionar(Curtida curtida)
        {
            try
            {
                _ctx.Curtida.Add(curtida);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Curtida BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Curtida.FirstOrDefault(c => c.IdCurtida == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Curtida> Listar()
        {
            try
            {
                return _ctx.Curtida.ToList();
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
                Curtida curtidaTemp = BuscarPorId(id);

                if (curtidaTemp == null)
                    throw new Exception("Curtida não encontrada");

                _ctx.Curtida.Remove(curtidaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
