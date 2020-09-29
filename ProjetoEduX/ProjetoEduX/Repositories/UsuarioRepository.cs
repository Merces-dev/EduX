using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly EduXContext _ctx;
        public UsuarioRepository()
        {
            _ctx = new EduXContext();
        }


        /// <summary>
        /// Adiciona um usuario
        /// </summary>
        /// <param name="usuario">usuario a ser adicionado</param>
        public void Adicionar(Usuario usuario)
        {
            try
            {
                _ctx.Usuario.Add(usuario);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca usuarios pelo id
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <returns>usuario</returns>
        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Usuario.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita um usuario ja criado
        /// </summary>
        /// <param name="usuario">usuario a ser editado</param>
        public void Editar(Usuario usuario)
        {
            try
            {

                Usuario usuarioTemp = BuscarPorId(usuario.IdUsuario);


                if (usuarioTemp == null)
                    throw new Exception("Usuário não encontrado");

                //Caso exista, fará a alteração
                usuarioTemp.Nome = usuario.Nome;
                usuarioTemp.Email = usuario.Email;
                usuarioTemp.Senha = usuario.Senha;
                usuarioTemp.DataCadastro = usuario.DataCadastro;
                usuarioTemp.DataUltimoAcesso = usuario.DataUltimoAcesso;
                usuarioTemp.IdPerfil = usuario.IdPerfil;


                _ctx.Usuario.Update(usuarioTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista os usuarios criados
        /// </summary>
        /// <returns>lista de usuarios</returns>
        public List<Usuario> Listar()
        {
            try
            {
                return _ctx.Usuario.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove usuarios pelo id
        /// </summary>
        /// <param name="id">id do usuario</param>
        public void Remover(Guid id)
        {
            try
            {

                Usuario usuarioTemp = BuscarPorId(id);


                _ctx.Usuario.Remove(usuarioTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

