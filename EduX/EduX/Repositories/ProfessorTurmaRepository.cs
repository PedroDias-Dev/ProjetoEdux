using EduX.Contexts;
using EduX.Domains;
using EduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Repositories
{
    public class ProfessorTurmaRepository : IProfessorTurmaRepository
    {

        private readonly EduxContext _ctx;
        public ProfessorTurmaRepository()
        {
            _ctx = new EduxContext();
        }




        //adiciona um professor
        public void Adicionar(ProfessorTurma professorT)
        {
            try
            {

                //adiciona o professor no contexto
                _ctx.ProfessorTurma.Add(professorT);
                //salva as alteracoes
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        //busca uma professor por id
        public ProfessorTurma BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.ProfessorTurma.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }




        //busca uma professor por nome
        public List<ProfessorTurma> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.ProfessorTurma.Where(p => p.Descricao.Contains(nome)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }




        //edita um professor
        public void Editar(ProfessorTurma professorT)
        {
            try
            {
                //busca professor pelo id
                ProfessorTurma professorTemp = BuscarPorId(professorT.IdProfessorTurma);
                //verifica se o professor existe no sistema, caso nao exista gera um exception
                if (professorTemp == null)
                    throw new Exception("O Porfessor inserido não foi encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //caso exista altera suas propriedades
                professorTemp.Descricao = professorT.Descricao;



                //altera professor no seu contexto
                _ctx.ProfessorTurma.Update(professorTemp);
                //salva suas alteraçoes
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }






        public List<ProfessorTurma> Listar()
        {
            try
            {
                return _ctx.ProfessorTurma.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //deleta um professor
        public void Remover(Guid id)
        {
            try
            {
                //busca o professor pelo id
                ProfessorTurma professorTemp = BuscarPorId(id);
                //verifica se o professor existe no sistema, caso nao exista gera um exception
                if (professorTemp == null)
                    throw new Exception("O Professor inserido não foi encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //remove o professor no contexto atual
                _ctx.ProfessorTurma.Remove(professorTemp);
                //salva as alteraçoes
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


    }
}