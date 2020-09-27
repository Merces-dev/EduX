using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Interfaces
{
    interface ICursoRepository
    {
        List<Curso> Listar();

        Curso BuscarPorId(Guid id);
        void Adicionar(Curso curso);
        void Editar(Curso curso);
        void Excluir(Guid id);

    }
}
