using System;
using System.Collections.Generic;

namespace EduX.Domains
{
    public partial class Curtida
    {
        public int IdCurtida { get; set; }
        public Guid Id { get; set; }
        public Guid? IdUsuario { get; set; }
        public int? IdDica { get; set; }

        public virtual Dica IdDicaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
