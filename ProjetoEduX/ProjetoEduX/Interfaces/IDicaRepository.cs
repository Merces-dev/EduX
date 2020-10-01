using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Interfaces
{
    interface IDicaRepository
    {
        Task<List<Dica>> Listar();

        Task<Dica> BuscarPorID(Guid id);

        Task<Dica> Adicionar(Dica dica);

        Task<Dica> Editar(Dica dica);

        Task<Dica> Remover(Dica dica);
    }
}
