using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEduX.Domains
{
    public partial class Turma : BaseDomain
    {
        public Turma()
        {
            AlunoTurma = new HashSet<AlunoTurma>();
            ProfessorTurma = new HashSet<ProfessorTurma>();
        }
        public Guid IdTurma { get; set; }
        public string Descricao { get; set; }
        public Guid? IdCurso { get; set; }
        [ForeignKey("IdCurso")]

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual ICollection<AlunoTurma> AlunoTurma { get; set; }
        public virtual ICollection<ProfessorTurma> ProfessorTurma { get; set; }
    }
}
