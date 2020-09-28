using EduX.Contexts;
using EduX.Domains;
using EduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly EduxContext _ctx;
        public CategoriaRepository()
        {
            _ctx = new EduxContext();
        }





        //adiciona uma categoria
        public void Adicionar(Categoria categoria)
        {
            try
            {

                //adiciona o objeto no contexto
                _ctx.Categoria.Add(categoria);
                //salva as alteracoes
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }







        //busca uma categoria por id
        public Categoria BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Categoria.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }









        //busca uma categoria por nome
        public List<Categoria> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Categoria.Where(p => p.Tipo.Contains(nome)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }







        //edita uma categoria
        public void Editar(Categoria categoria)
        {
            try
            {
                //busca categoria pelo id
                Categoria categoriaTemp = BuscarPorId(categoria.IdCategoria);
                //verifica se a categoria existe no sistema, caso nao exista gera um exception
                if (categoriaTemp == null)
                    throw new Exception("A Categoria inserida não foi encontrada no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //caso exista altera suas propriedades
                categoriaTemp.Tipo = categoria.Tipo;



                //altera categoria no seu contexto
                _ctx.Categoria.Update(categoriaTemp);
                //salva suas alteraçoes
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }










        public List<Categoria> Listar()
        {
            try
            {
                return _ctx.Categoria.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }









        //deleta uma categoria
        public void Remover(Guid id)
        {
            try
            {
                //busca uma categoria pelo id
                Categoria categoriaTemp = BuscarPorId(id);
                //verifica se a categoria existe no sistema, caso nao exista gera um exception
                if (categoriaTemp == null)
                    throw new Exception("A Categoria inserida não foi encontrada no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //remove categoria no contexto atual
                _ctx.Categoria.Remove(categoriaTemp);
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


