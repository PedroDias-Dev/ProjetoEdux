using EduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Interfaces
{
    public interface ITurmaRepository
    {
        List<Turma> Listar();
        Turma BuscarPorId(Guid id);
        List<Turma> BuscarPorNome(string nome);
        void Adicionar(Turma turma);
        void Editar(Turma turma);
        void Remover(Guid id);
    }
}
