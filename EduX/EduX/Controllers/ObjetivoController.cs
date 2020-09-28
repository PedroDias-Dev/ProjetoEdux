using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EduX.Domains;
using EduX.Interfaces;
using EduX.Repositories;
//using EduX.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetivosController : ControllerBase
    {
        private readonly IObjetivoRepository objetivoRepository;

        public ObjetivosController()
        {
            objetivoRepository = new ObjetivoRepository();
        }



        /// <summary>
        /// Mostra todo os objetivos cadastrados
        /// </summary>
        /// <returns>Lista com todos os objetivos cadastrados</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //lista de objetivos
                var objetivos = objetivoRepository.Listar();

                //verifica se existe no conxtexto atual
                //caso nao exista ele retorna NoContext
                if (objetivos.Count == 0)
                    return NoContent();

                //caso exista retorno Ok e o total de objetivos cadastrados
                return Ok(new
                {
                    totalCount = objetivos.Count,
                    data = objetivos
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // GET api/<ObjetivosController>/5
        /// <summary>
        /// Mostra um único objetivo 
        /// </summary>
        /// <param name="id">ID do objetivo</param>
        /// <returns>Um objetivo</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //busca um objetivo por id
                Objetivo objetiv = objetivoRepository.BuscarPorId(id);

                //faz a verificacao no contexto para ver se o objetivo foi encontrado
                //caso nao for encontrado o sistema retornara NotFound 
                if (objetiv == null)
                    return NotFound();

                //se existir retorno vai passar o Ok e os dados do objetivo  
                return Ok(objetiv);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }


        // POST api/<ObjetivosController>
        /// <summary>
        /// Cadastra um novo objetivo
        /// </summary>
        /// <param name="objetivo">Objeto completo de objetivo</param>
        /// <returns>Objetivo cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromForm] Objetivo objetivo)
        {
            try
            {
                //adiciona um novo objetivo
                objetivoRepository.Adicionar(objetivo);

                //retorna Ok se o objetivo tiver sido cadastrado
                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }




        // PUT api/<ObjetivosController>/5
        /// <summary>
        /// Altera determinado objetivo
        /// </summary>
        /// <param name="id">ID de objetivo</param>
        /// <param name="objetivo">Objeto objetivo com as alterações</param>
        /// <returns>Info do objetivo alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Objetivo objetivo)
        {
            try
            {
                //edita objetivo
                objetivoRepository.Editar(objetivo);

                //retorna o Ok com os dados do objetivo
                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        // DELETE api/<ObjetivosController>/5
        /// <summary>
        /// Exclui um objetivo
        /// </summary>
        /// <param name="id">ID do objetivo</param>
        /// <returns>ID excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //busca objetivo pelo Id
                var objetiv = objetivoRepository.BuscarPorId(id);

                //verifica se objetivo existe
                //caso não exista retorna NotFound
                if (objetiv == null)
                    return NotFound();

                //caso exista remove o objetivo
                objetivoRepository.Remover(id);
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