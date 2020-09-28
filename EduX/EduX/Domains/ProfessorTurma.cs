using System;
using System.Collections.Generic;

namespace EduX.Domains
{
    public partial class ProfessorTurma
    {
        public Guid IdProfessorTurma { get; set; }
        public string Descricao { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdTurma { get; set; }

        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
