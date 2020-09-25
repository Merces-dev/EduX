using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly EduXContext _ctx;
        public PerfilRepository()
        {
            _ctx = new EduXContext();
        }
        public void Adicionar(Perfil perfil)
        {
            try
            {
                _ctx.Perfil.Add(perfil);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Perfil BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Perfil.FirstOrDefault(c => c.IdPerfil == id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Editar(Perfil perfil)
        {
            try
            {
                Perfil perfilTemp = BuscarPorId(perfil.IdPerfil);

                if (perfilTemp == null)
                    throw new Exception("Perfil não encontrado");

                perfilTemp.Permissao = perfil.Permissao;

                _ctx.Perfil.Update(perfilTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Perfil> Listar()
        {
            try
            {
                return _ctx.Perfil.ToList();
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
                Perfil perfilTemp = BuscarPorId(id);

                if (perfilTemp == null)
                    throw new Exception("Perfil não encontrado");

                _ctx.Perfil.Remove(perfilTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
