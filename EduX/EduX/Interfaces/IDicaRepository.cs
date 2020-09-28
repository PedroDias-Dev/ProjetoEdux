using EduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Interfaces
{
    interface IDicaRepository
    {
        public void Cadastrar(Dica dica);
        public void Alterar(Dica dica);
        public Dica BuscarPorId(Guid id);
        public void Deletar(Guid id);
        public List<Dica> Listar();
    }
}
