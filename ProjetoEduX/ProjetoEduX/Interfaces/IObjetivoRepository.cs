using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Interfaces
{
    interface IObjetivoRepository
    {
        /// <summary>
        /// Lista todos os objetivos
        /// </summary>
        /// <returns>Todos os objetivos</returns>
        List<Objetivo> Listar();
        /// <summary>
        /// Busca um objetivo através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O objetivo solicitado pelo Id</returns>
        Objetivo BuscarPorId(Guid id);
        /// <summary>
        /// Adiciona um objetivo
        /// </summary>
        /// <param name="objetivo"></param>
        void Adicionar(Objetivo objetivo);
        /// <summary>
        /// Edita um dado de objetivo
        /// </summary>
        /// <param name="objetivo"></param>
        void Editar(Objetivo objetivo);
        /// <summary>
        /// Remove um objetivo
        /// </summary>
        /// <param name="id"></param>
        void Remover(Guid id);
    }
}
