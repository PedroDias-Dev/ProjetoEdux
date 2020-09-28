using EduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Interfaces
{
    public interface ICategoriaRepository
    {
        List<Categoria> Listar();
        Categoria BuscarPorId(Guid id);
        List<Categoria> BuscarPorNome(string nome);
        void Adicionar(Categoria categoria);
        void Editar(Categoria categoria);
        void Remover(Guid id);
    }
}
