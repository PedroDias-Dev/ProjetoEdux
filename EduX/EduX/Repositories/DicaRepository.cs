using EduX.Contexts;
using EduX.Domains;
using EduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Repositories
{
    public class DicaRepository : IDicaRepository
    {
        #region Context
        private readonly EduxContext context;

        public DicaRepository()
        {
            context = new EduxContext();
        }
        #endregion

        #region Alterar
        public void Alterar(Dica dica)
        {
            try
            {
                Dica dicaTemp = BuscarPorId(dica.IdDica);

                //propriedades
                dicaTemp.Texto = dica.Texto;
                dicaTemp.Imagem = dica.Imagem;
                dicaTemp.IdUsuario = dica.IdUsuario;
                dicaTemp.IdUsuarioNavigation = dica.IdUsuarioNavigation;
                dicaTemp.Curtida = dica.Curtida;

                //Altera no banco
                context.Dica.Update(dicaTemp);

                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region BuscarID
        public Dica BuscarPorId(Guid id)
        {
            try
            {
                return context.Dica.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Cadastrar
        public void Cadastrar(Dica dica)
        {
            try
            {
                context.Dica.Add(dica);

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
                Dica dicaTemp = BuscarPorId(id);

                if (dicaTemp == null)
                    //caso não exista retorna a mensagem
                    throw new Exception("Dica não encontrada");

                //caso exista remove a dica
                context.Dica.Remove(dicaTemp);

                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Listar
        public List<Dica> Listar()
        {
            try
            {
                return context.Dica.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
