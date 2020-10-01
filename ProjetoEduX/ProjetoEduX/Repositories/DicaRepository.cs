using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class DicaRepository : IDicaRepository
    {
        public Task<Dica> Editar(Dica dica)
        {
            throw new NotImplementedException();
        }

        public Task<Dica> BuscarPorID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Dica> Remover(Dica dica)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dica>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<Dica> Adicionar(Dica dica)
        {
            throw new NotImplementedException();
        }
    }
}
