using EduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(Guid id);
        void Adicionar(Usuario user);
        void Editar(Usuario user);
        void Remover(Guid id);
    }
}
