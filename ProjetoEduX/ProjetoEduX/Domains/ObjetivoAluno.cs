using System;
using System.Collections.Generic;

namespace ProjetoEduX.Domains
{
    public partial class ObjetivoAluno 
    {
        public Guid IdObjetivoAluno { get; set; }
        public decimal? Nota { get; set; }
        public DateTime? DataAlcancado { get; set; }
        public Guid? IdAlunoTurma { get; set; }
        public Guid? IdObjetivo { get; set; }

        public virtual AlunoTurma IdAlunoTurmaNavigation { get; set; }
        public virtual Objetivo IdObjetivoNavigation { get; set; }
    }
}
