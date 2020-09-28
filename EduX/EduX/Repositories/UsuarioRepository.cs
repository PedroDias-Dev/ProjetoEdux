using EduX.Contexts;
using EduX.Domains;
using EduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private EduxContext _ctx = new EduxContext();

        #region Leitura
        // Lista todos os usuarios cadastrados
        public List<Usuario> Listar()
        {
            try
            {
                return _ctx.Usuario.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Busca um usuario por Id
        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Usuario.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Gravação
        // Edita um usuario
        public void Editar(Usuario user)
        {
            try
            {
                //Busca usuario pelo id
                Usuario userTemp = BuscarPorId(user.IdUsuario);

                //Caso não existe gera uma exception
                if (userTemp == null)
                    throw new Exception("Usuario não encontrado");

                userTemp.Nome = user.Nome;
                userTemp.Email = user.Email;
                userTemp.Senha = user.Senha;

                //Altera usuario no context
                _ctx.Usuario.Update(userTemp);
                //Salva o contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Cadastra novo usuario
        public void Adicionar(Usuario user)
        {
            try
            {
                //Adiciona novo usuario ao context do dbset
                _ctx.Usuario.Add(user);

                //Salva a alteração
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Remove um usuario
        public void Remover(Guid id)
        {
            try
            {
                //Busca usuario pelo id
                Usuario userTemp = BuscarPorId(id);

                //Remove o usuario do dbSet
                _ctx.Usuario.Remove(userTemp);
                //Salva a alteração
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
