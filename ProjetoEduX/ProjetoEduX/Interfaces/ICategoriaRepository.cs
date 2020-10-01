using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Interfaces
{
    interface ICategoriaRepository
    {
        Task<List<Categoria>> Listar();

        Task<Categoria> BuscarPorID(Guid id);

        Task<Categoria> Adicionar(Categoria categoria);

        Task<Categoria> Editar(Categoria categoria);

        Task<Categoria> Remover(Categoria categoria);
    }
}
