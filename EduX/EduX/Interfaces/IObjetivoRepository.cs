using EduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Interfaces
{
    public interface IObjetivoRepository
    {
        List<Objetivo> Listar();
        Objetivo BuscarPorId(Guid id);
        List<Objetivo> BuscarPorNome(string nome);
        void Adicionar(Objetivo objetivo);
        void Editar(Objetivo objetivo);
        void Remover(Guid id);

    }
}
