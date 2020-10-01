using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public Task<Categoria> Editar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> BuscarPorID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> Remover(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<List<Categoria>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> Adicionar(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
