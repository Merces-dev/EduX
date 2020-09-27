using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Interfaces
{
    interface IProfessorTurmaRepository
    {
        /// <summary>	
        /// Lista todos os professores	
        /// </summary>	
        /// <returns>Os professores</returns>	
        List<ProfessorTurma> Listar();

        /// <summary>	
        /// Busca um professor pelo id	
        /// </summary>	
        /// <param name="id"></param>	
        /// <returns>O professor solicitado pelo id</returns>	
        ProfessorTurma BuscarPorId(Guid id);

        /// <summary>	
        /// Adiciona um professor 	
        /// </summary>	
        /// <param name="professorturma"></param>	
        void Adicionar(ProfessorTurma professorturma);

        /// <summary>	
        /// Edita as informações de um professor	
        /// </summary>	
        /// <param name="professorturma"></param>	
        void Editar(ProfessorTurma professorturma);

        /// <summary>	
        /// Remove um professor	
        /// </summary>	
        /// <param name="id"></param>	
        void Remover(Guid id);

    }

}