using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Interfaces
{
    interface IObjetivoAlunoRepository
    {
        /// <summary>
        /// Lista todos os objetivos de aluno
        /// </summary>
        /// <returns>Todos os objetivos de aluno</returns>
        List<ObjetivoAluno> Listar();
        /// <summary>
        /// Busca um objetivo através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O objetivo aluno solicitado pelo Id</returns>
        ObjetivoAluno BuscarPorId(Guid id);
        /// <summary>
        /// Adiciona um objetivo objetivo aluno
        /// </summary>
        /// <param name="objetivoaluno"></param>
        void Adicionar(ObjetivoAluno objetivoaluno);
        /// <summary>
        /// Edita um dado de objetivo aluno
        /// </summary>
        /// <param name="objetivoaluno"></param>
        void Editar(ObjetivoAluno objetivoaluno);
        /// <summary>
        /// Remove um objetivo aluno
        /// </summary>
        /// <param name="id"></param>
        void Remover(Guid id);
    }
}
