using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEduX.Domains
{
    public partial class Curtida : BaseDomain
    {
        public Guid IdCurtida { get; set; }
        public Guid? IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Guid? IdDica { get; set; }
        [ForeignKey("IdDica")]

        public virtual Dica IdDicaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
