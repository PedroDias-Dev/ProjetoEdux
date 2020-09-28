using System;
using System.Collections.Generic;

namespace EduX.Domains
{
    public partial class ObjetivoAluno
    {
        public Guid IdOjetivoAluno { get; set; }
        public decimal? Nome { get; set; }
        public DateTime? DataAlcancado { get; set; }
        public Guid? IdAlunoTurma { get; set; }
        public Guid? IdObjetivo { get; set; }

        public virtual AlunoTurma IdAlunoTurmaNavigation { get; set; }
        public virtual Objetivo IdObjetivoNavigation { get; set; }
    }
}
