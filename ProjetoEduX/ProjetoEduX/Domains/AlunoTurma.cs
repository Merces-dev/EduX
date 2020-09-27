using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEduX.Domains
{
    public partial class AlunoTurma:BaseDomain
    {
        public AlunoTurma()
        {
            ObjetivoAluno = new HashSet<ObjetivoAluno>();
        }

        public Guid IdAlunoTurma { get; set; }
        public string Matricula { get; set; }
        public Guid? IdTurma { get; set; }
        [ForeignKey("IdTurma")]
        public Guid? IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]

        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<ObjetivoAluno> ObjetivoAluno { get; set; }
    }
}
