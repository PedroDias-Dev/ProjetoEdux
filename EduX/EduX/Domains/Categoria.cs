using System;
using System.Collections.Generic;

namespace EduX.Domains
{
    public partial class Categoria
    {
        public Categoria()
        {
            Objetivo = new HashSet<Objetivo>();
        }

        public int IdCategoria { get; set; }
        public Guid Id { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Objetivo> Objetivo { get; set; }
    }
}
