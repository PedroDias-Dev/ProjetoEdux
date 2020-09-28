using EduX.Contexts;
using EduX.Domains;
using EduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        #region Context
        private readonly EduxContext context;

        public InstituicaoRepository()
        {
            context = new EduxContext();
        }
        #endregion

        #region Alterar
        public void Alterar(Instituicao instituicao)
        {
            try
            {
                Instituicao instituicaoTemp = BuscarPorId(instituicao.IdInstituicao);

                //propriedades
                instituicaoTemp.Nome = instituicao.Nome;
                instituicaoTemp.Logradouro = instituicao.Logradouro;
                instituicaoTemp.Numero = instituicao.Numero;
                instituicaoTemp.Complemento = instituicao.Complemento;
                instituicaoTemp.Bairro = instituicao.Bairro;
                instituicaoTemp.Cidade = instituicao.Cidade;
                instituicaoTemp.Uf = instituicao.Uf;
                instituicaoTemp.Cep = instituicao.Cep;


                //Altera no banco
                context.Instituicao.Update(instituicaoTemp);

                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region BuscarID
        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                return context.Instituicao.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Cadastrar
        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                context.Instituicao.Add(instituicao);

                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Deletar
        public void Deletar(Guid id)
        {
            try
            {
                Instituicao instituicaoTemp = BuscarPorId(id);

                if (instituicaoTemp == null)
                    //caso não exista retorna a mensagem
                    throw new Exception("INstituição não encontrada");

                //caso exista remove o curso
                context.Instituicao.Remove(instituicaoTemp);

                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Listar
        public List<Instituicao> Listar()
        {
            try
            {
                return context.Instituicao.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
