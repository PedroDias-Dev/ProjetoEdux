using EduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Interfaces
{
    interface ICursoRepository
    {
        public void Cadastrar(Curso curso);
        public void Alterar(Curso curso);
        public Curso BuscarPorId(Guid id);
        public void Deletar(Guid id);
        public List<Curso> Listar();
    }
}
