using EduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Interfaces
{
    interface IObjetivoAlunoRepository
    {
        public void Cadastrar(ObjetivoAluno objetivoAluno);
        public void Alterar(ObjetivoAluno objetivoAluno);
        public ObjetivoAluno BuscarPorId(Guid id);
        public void Deletar(Guid id);
        public List<ObjetivoAluno> Listar();
    }
}
