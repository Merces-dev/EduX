using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;

namespace ProjetoEduX.Interfaces
{
    interface IDicaRepository
    {
        List<Dica> Listar();
        Dica BuscarPorId(Guid id);
        void Adicionar(Dica dica);
        void Editar(Dica dica);
        void Remover(Guid id);
    }
}
