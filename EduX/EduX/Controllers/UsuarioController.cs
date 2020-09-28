using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduX.Contexts;
using EduX.Domains;
using EduX.Repositories;
using EduX.Interfaces;

namespace EduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _userRepository;
        public UsuarioController()
        {
            _userRepository = new UsuarioRepository();
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            try
            {
                var usuarios = _userRepository.Listar();

                //Verifica se tem usuarios
                if (usuarios.Count == 0)
                    return NoContent();

                //Caso exista retorna OK
                return Ok(new
                {
                    totalCount = usuarios.Count,
                    data = usuarios
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Ocorreu um erro ao obter os usuarios, revise seu request ou envie um e-mail para email@email.com informando [400 Code]"
                });
            }
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(Guid id)
        {
            try
            {
                //Busco o produto pelo Id
                Usuario usuario = _userRepository.BuscarPorId(id);

                //Verifico se o produto foi encontrado
                //Caso não exista retorno NotFounf
                if (usuario == null)
                    return NotFound();

                //Caso exista retorno Ok e os dados do produto
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Usuario usuario)
        {
            try
            {
                //Edita o produto
                _userRepository.Editar(usuario);

                //Retorna Ok com os dados do produto
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            try
            {
                //Adiciona um novo produto
                _userRepository.Adicionar(usuario);

                //Retorna Ok caso o produto tenha sido cadastrado
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(Guid id)
        {
            try
            {
                //Busca o produto pelo Id
                var usuario = _userRepository.BuscarPorId(id);

                //Verifica se produto existe
                //Caso não exista retorna NotFound
                if (usuario == null)
                    return NotFound();

                //Caso exista remove o produto
                _userRepository.Remover(id);
                //Retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //private bool UsuarioExists(Guid id)
        //{
            //return _context.Usuario.Any(e => e.IdUsuario == id);
        //}
    }
}
