using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEduX.Domains
{
    public partial class Curso : BaseDomain
    {
        public Curso()
        {
            Turma = new HashSet<Turma>();
        }
        public Guid IdCurso { get; set; }
        public string Titulo { get; set; }
        public Guid? IdInstituicao { get; set; }
        [ForeignKey("IdInstituicao")]

        public virtual Instituicao IdInstituicaoNavigation { get; set; }
        public virtual ICollection<Turma> Turma { get; set; }
    }
}
