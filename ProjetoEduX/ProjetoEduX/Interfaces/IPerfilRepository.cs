using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Interfaces
{
    interface IPerfilRepository
    {
        List<Perfil> Listar();
        Perfil BuscarPorId(Guid id);
        void Adicionar(Perfil perfil);
        void Editar(Perfil perfil);
        void Remover(Guid id);
    }
}
