using EduX.Contexts;
using EduX.Domains;
using EduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {

        private readonly EduxContext _ctx;
        public TurmaRepository()
        {
            _ctx = new EduxContext();
        }





        //adiciona uma turma
        public void Adicionar(Turma turma)
        {
            try
            {

                //adiciona o objeto no contexto
                _ctx.Turma.Add(turma);
                //salva as alteracoes
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }







        //busca uma turma por id
        public Turma BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Turma.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }









        //busca uma turma por nome
        public List<Turma> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Turma.Where(p => p.Descricao.Contains(nome)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }






        //edita uma turma
        public void Editar(Turma turma)
        {
            try
            {
                //busca turma pelo id
                Turma turmaTemp = BuscarPorId(turma.IdTurma);
                //verifica se a turma existe no sistema, caso nao exista gera um exception
                if (turmaTemp == null)
                    throw new Exception("A Turma inserida não foi encontrada no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //caso exista altera suas propriedades
                turmaTemp.Descricao = turma.Descricao;



                //altera turma no seu contexto
                _ctx.Turma.Update(turmaTemp);
                //salva suas alteraçoes
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }










        public List<Turma> Listar()
        {
            try
            {
                return _ctx.Turma.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }









        //deleta uma turma
        public void Remover(Guid id)
        {
            try
            {
                //busca uma turma pelo id
                Turma turmaTemp = BuscarPorId(id);
                //verifica se a turma existe no sistema, caso nao exista gera um exception
                if (turmaTemp == null)
                    throw new Exception("A Turma inserida não foi encontrada no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //remove turma no contexto atual
                _ctx.Turma.Remove(turmaTemp);
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



