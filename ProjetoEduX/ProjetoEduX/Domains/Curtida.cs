using System;
using System.Collections.Generic;

namespace ProjetoEduX.Domains
{
    public partial class Curtida
    {
        public Guid IdCurtida { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdDica { get; set; }

        public virtual Dica IdDicaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
