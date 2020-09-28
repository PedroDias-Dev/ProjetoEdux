using EduX.Contexts;
using EduX.Domains;
using EduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        #region Context
        private readonly EduxContext context;

        public CursoRepository()
        {
            context = new EduxContext();
        }
        #endregion

        #region Alterar
        public void Alterar(Curso curso)
        {
            try
            {
                Curso cursoTemp = BuscarPorId(curso.IdCurso);

                //propriedades
                cursoTemp.Titulo = curso.Titulo;
                cursoTemp.IdInstituicao = curso.IdInstituicao;
                cursoTemp.IdInstituicaoNavigation = curso.IdInstituicaoNavigation;
                cursoTemp.Turma = curso.Turma;


                //Altera no banco
                context.Curso.Update(cursoTemp);

                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region BuscarID
        public Curso BuscarPorId(Guid id)
        {
            try
            {
                return context.Curso.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Cadastrar
        public void Cadastrar(Curso curso)
        {
            try
            {
                context.Curso.Add(curso);

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
                Curso cursoTemp = BuscarPorId(id);

                if (cursoTemp == null)
                    //caso não exista retorna a mensagem
                    throw new Exception("Curso não encontrado");

                //caso exista remove o curso
                context.Curso.Remove(cursoTemp);

                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Listar
        public List<Curso> Listar()
        {
            try
            {
                return context.Curso.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
