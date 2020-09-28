using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;

namespace ProjetoEduX.Interfaces
{
    interface IInstituicaoRepository
    {
        List<Instituicao> Listar();

        Instituicao BuscarPorId(Guid id);
        void Adicionar(Instituicao instituicao);
        void Editar(Instituicao instituicao);
        void Remover(Guid id);

    }
}