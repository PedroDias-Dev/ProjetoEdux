using EduX.Contexts;
using EduX.Domains;
using EduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Repositories
{
    public class ObjetivoRepository : IObjetivoRepository
    {

        private readonly EduxContext _ctx;
        public ObjetivoRepository()
        {
            _ctx = new EduxContext();
        }





        //adiciona um objetivo
        public void Adicionar(Objetivo objetivo)
        {
            try
            {

                //adiciona o objeto no contexto
                _ctx.Objetivo.Add(objetivo);
                //salva as alteracoes
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }






        //busca uma objetivo por id
        public Objetivo BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Objetivo.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }









        //busca uma objetivo por nome
        public List<Objetivo> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Objetivo.Where(p => p.Descricao.Contains(nome)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }







        //edita um objetivo
        public void Editar(Objetivo objetivo)
        {
            try
            {
                //busca objetivo pelo id
                Objetivo objetivoTemp = BuscarPorId(objetivo.IdObjetivo);
                //verifica se o objetivo existe no sistema, caso nao exista gera um exception
                if (objetivoTemp == null)
                    throw new Exception("O Objetivo inserido não foi encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //caso exista altera suas propriedades
                objetivoTemp.Descricao = objetivo.Descricao;



                //altera objetivo no seu contexto
                _ctx.Objetivo.Update(objetivoTemp);
                //salva suas alteraçoes
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }










        public List<Objetivo> Listar()
        {
            try
            {
                return _ctx.Objetivo.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }









        //deleta um objetivo
        public void Remover(Guid id)
        {
            try
            {
                //busca um objetivo pelo id
                Objetivo objetivoTemp = BuscarPorId(id);
                //verifica se o objetivo existe no sistema, caso nao exista gera um exception
                if (objetivoTemp == null)
                    throw new Exception("O Objetivo inserido não foi encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //remove objetivo no contexto atual
                _ctx.Objetivo.Remove(objetivoTemp);
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


