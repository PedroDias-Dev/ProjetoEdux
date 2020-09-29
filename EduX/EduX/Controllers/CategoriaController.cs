using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EduX.Domains;
using EduX.Interfaces;
using EduX.Repositories;
using Microsoft.AspNetCore.Authorization;
//using EduX.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduX.Controllers
{
    [Authorize(Roles = "Padrao,Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriasController()
        {
            categoriaRepository = new CategoriaRepository();
        }

        /// <summary>
        /// Mostra todas as categorias cadastradas
        /// </summary>
        /// <returns>Lista com todas as categorias</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //lista de categorias
                var categorias = categoriaRepository.Listar();

                //verifica se existe no conxtexto atual
                //caso nao exista ele retorna NoContext
                if (categorias.Count == 0)
                    return NoContent();

                //caso exista retorno Ok e o total de categorias cadastradas
                return Ok(new
                {
                    totalCount = categorias.Count,
                    data = categorias
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // GET api/<CategoriasController>/5
        /// <summary>
        /// Mostra uma única categoria
        /// </summary>
        /// <param name="id">ID da categoria</param>
        /// <returns>Uma categoria</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //busca uma categoria por id
                Categoria categori = categoriaRepository.BuscarPorId(id);

                //faz a verificacao no contexto para ver se a categoria foi encontrada
                //caso nao for encontrada o sistema retornara NotFound 
                if (categori == null)
                    return NotFound();

                //se existir retorno vai passar o Ok e os dados da categoria  
                return Ok(categori);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }


        // POST api/<CategoriasController>
        /// <summary>
        /// Cadastra uma nova categoria
        /// </summary>
        /// <param name="categoria">Objeto completo de categoria</param>
        /// <returns>Categoria cadastrada</returns>
        [HttpPost]
        public IActionResult Post([FromForm] Categoria categoria)
        {
            try
            {
                //adiciona uma nova categoria
                categoriaRepository.Adicionar(categoria);

                //retorna Ok se a categoria tiver sido cadastrada
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }



        // PUT api/<CatgeoriasController>/5
        /// <summary>
        /// Altera determinada categoria
        /// </summary>
        /// <param name="id">ID de categoria</param>
        /// <param name="categoria">Objeto categoria com as alterações</param>
        /// <returns>Info da categoria alterada</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Categoria categoria)
        {
            try
            {
                //edita categoria
                categoriaRepository.Editar(categoria);

                //retorna o Ok com os dados da categoria
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<CategoriasController>/5
        /// <summary>
        /// Exclui uma categoria
        /// </summary>
        /// <param name="id">ID da categoria</param>
        /// <returns>ID excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //busca categoria pelo Id
                var categori = categoriaRepository.BuscarPorId(id);

                //verifica se categoria existe
                //caso não exista retorna NotFound
                if (categori == null)
                    return NotFound();

                //caso exista remove a categoria
                categoriaRepository.Remover(id);
                //retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
