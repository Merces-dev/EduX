using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduXGrupo.Interfaces
{
    interface IAlunoTurmaRepository
    {
        List<AlunoTurma> Listar();

        AlunoTurma BuscarPorId(Guid id);
        void Adicionar(AlunoTurma alunoturma);
        void Editar(AlunoTurma alunoturma);
        void Remover(Guid id);

    }
}