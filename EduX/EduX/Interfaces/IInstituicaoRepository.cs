using EduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Interfaces
{
    interface IInstituicaoRepository
    {
        public void Cadastrar(Instituicao instituicao);
        public void Alterar(Instituicao instituicao);
        public Instituicao BuscarPorId(Guid id);
        public void Deletar(Guid id);
        public List<Instituicao> Listar();
    }
}
