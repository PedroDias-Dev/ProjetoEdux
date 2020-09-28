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
    public class TurmasController : ControllerBase
    {
        private readonly ITurmaRepository turmaRepository;

        public TurmasController()
        {
            turmaRepository = new TurmaRepository();
        }



        /// <summary>
        /// Mostra todas as turmas cadastradas
        /// </summary>
        /// <returns>Lista com todas as turmas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //lista de turmas
                var turmas = turmaRepository.Listar();

                //verifica se existe no conxtexto atual
                //caso nao exista ele retorna NoContext
                if (turmas.Count == 0)
                    return NoContent();

                //caso exista retorno Ok e o total de turmas cadastradas
                return Ok(new
                {
                    totalCount = turmas.Count,
                    data = turmas
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // GET api/<TurmasController>/5
        /// <summary>
        /// Mostra uma única turma
        /// </summary>
        /// <param name="id">ID da turma</param>
        /// <returns>Uma turma</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //busca uma turma por id
                Turma turm = turmaRepository.BuscarPorId(id);

                //faz a verificacao no contexto para ver se a turma foi encontrada
                //caso nao for encontrado o sistema retornara NotFound 
                if (turm == null)
                    return NotFound();

                //se existir retorno vai passar o Ok e os dados da turma  
                return Ok(turm);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }



        // POST api/<TurmasController>
        /// <summary>
        /// Cadastra uma nova turma
        /// </summary>
        /// <param name="turma">Objeto completo de turma</param>
        /// <returns>Turma cadastrada</returns>
        [HttpPost]
        public IActionResult Post([FromForm] Turma turma)
        {
            try
            {
                //adiciona uma nova turma
                turmaRepository.Adicionar(turma);

                //retorna Ok se a turma tiver sido cadastrada
                return Ok(turma);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }




        // PUT api/<TurmasController>/5
        /// <summary>
        /// Altera determinada turma
        /// </summary>
        /// <param name="id">ID de turma</param>
        /// <param name="jogador">Objeto turma com as alterações</param>
        /// <returns>Info da turma alterada</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Turma turma)
        {
            try
            {
                //edita turma
                turmaRepository.Editar(turma);

                //retorna o Ok com os dados da turma
                return Ok(turma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // DELETE api/<TurmasController>/5
        /// <summary>
        /// Exclui uma turma
        /// </summary>
        /// <param name="id">ID da turma</param>
        /// <returns>ID excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //busca turma pelo Id
                var turm = turmaRepository.BuscarPorId(id);

                //verifica se turma existe
                //caso não exista retorna NotFound
                if (turm == null)
                    return NotFound();

                //caso exista remove a turma
                turmaRepository.Remover(id);
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
