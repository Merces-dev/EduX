using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Interfaces
{
    interface ITurmaRepository 
    {
        List<Turma> Listar();

        Turma BuscarPorId(Guid id);
        void Adicionar(Turma turma);
        void Editar(Turma turma);
        void Excluir(Guid id);
    }
}
