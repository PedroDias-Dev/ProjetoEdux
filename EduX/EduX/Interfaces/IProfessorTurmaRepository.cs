using EduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Interfaces
{
    public interface IProfessorTurmaRepository
    {
        List<ProfessorTurma> Listar();
        ProfessorTurma BuscarPorId(Guid id);
        List<ProfessorTurma> BuscarPorNome(string nome);
        void Adicionar(ProfessorTurma professorT);
        void Editar(ProfessorTurma professorT);
        void Remover(Guid id);
    }
}
