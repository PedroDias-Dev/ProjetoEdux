using EduX.Contexts;
using EduX.Domains;
using EduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Repositories
{
    public class ObjetivoAlunoRepository : IObjetivoAlunoRepository
    {
        #region Context
        private readonly EduxContext context;

        public ObjetivoAlunoRepository()
        {
            context = new EduxContext();
        }
        #endregion

        #region Alterar
        public void Alterar(ObjetivoAluno objetivoAluno)
        {

            try
            {
                ObjetivoAluno objetivoAlunoTemp = BuscarPorId(objetivoAluno.IdOjetivoAluno);

                //propriedades
                objetivoAlunoTemp.Nome = objetivoAluno.Nome;
                objetivoAlunoTemp.DataAlcancado = objetivoAluno.DataAlcancado;
                objetivoAlunoTemp.IdAlunoTurma = objetivoAluno.IdAlunoTurma;
                objetivoAluno.IdObjetivo = objetivoAluno.IdObjetivo;
                objetivoAlunoTemp.IdAlunoTurmaNavigation = objetivoAluno.IdAlunoTurmaNavigation;
                objetivoAlunoTemp.IdObjetivoNavigation = objetivoAluno.IdObjetivoNavigation;


                //Altera no banco
                context.ObjetivoAluno.Update(objetivoAlunoTemp);

                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region BuscarID
        public ObjetivoAluno BuscarPorId(Guid id)
        {
            try
            {
                return context.ObjetivoAluno.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Cadastrar
        public void Cadastrar(ObjetivoAluno objetivoAluno)
        {
            try
            {
                context.ObjetivoAluno.Add(objetivoAluno);

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
                ObjetivoAluno objetivoAlunoTemp = BuscarPorId(id);

                if (objetivoAlunoTemp == null)
                    //caso não exista retorna a mensagem
                    throw new Exception("Objetivo do aluno não encontrado");

                //caso exista remove o curso
                context.ObjetivoAluno.Remove(objetivoAlunoTemp);

                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Listar
        public List<ObjetivoAluno> Listar()
        {
            try
            {
                return context.ObjetivoAluno.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
