using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Interfaces
{
    interface ICurtidaRepository
    {
        List<Curtida> Listar();

        Curtida BuscarPorId(Guid id);
        void Adicionar(Curtida curtida);
        void Remover(Guid id);
    }
}
