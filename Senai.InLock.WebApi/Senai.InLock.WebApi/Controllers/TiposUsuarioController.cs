using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class TiposUsuarioController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _tipoUsuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private ITiposUsuariosRepository _tipoUsuarioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public TiposUsuarioController()
        {
            _tipoUsuarioRepository = new TiposUsuariosRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Retorna uma lista de tipos de usuário e um status code 200 - Ok</returns>
        /// dominio/api/TiposUsuario
        /// <response code="200">Se a lista for acessada com êxito</response>
        /// <response code="400">Erro em alguma parte da requisição</response>
        /// <response code="401">Se o usuário não estiver logado</response>
        /// <response code="403">Se o usuário não tiver permissão para tal ação</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Get()
        {
            // Faz a chamada para o método .Listar()
            // Retorna a lista e um status code 200 - Ok
            return Ok(_tipoUsuarioRepository.Listar());
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        /// <returns>Retorna os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/TiposUsuario
        /// <response code="201">Se o objeto for criado com êxito</response>
        /// <response code="400">Erro em alguma parte da requisição</response>
        /// <response code="401">Se o usuário não estiver logado</response>
        /// <response code="403">Se o usuário não tiver permissão para tal ação</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Post(TiposUsuariosDomain novoTipoUsuario)
        {
            // Faz a chamada para o método .Cadastrar();
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            // Retorna o status code 201 - Created com a URI e o objeto cadastrado
            return Created("http://localhost:5000/api/TiposUsuario", novoTipoUsuario);
        }

        /// <summary>
        /// Busca um tipo de usuário através do seu ID
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será buscado</param>
        /// <returns>Retorna um tipo de usuário buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/TiposUsuario/1
        /// <response code="200">Se a lista for acessada</response>
        /// <response code="400">Erro em alguma parte da requisição</response>
        /// <response code="401">Se o usuário não estiver logado</response>
        /// <response code="403">Se o usuário não tiver permissão para tal ação</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetById(int id)
        {
            // Cria um objeto tipoUsuarioBuscado que irá receber o tipo de usuário buscado no banco de dados
            TiposUsuariosDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            // Verifica se algum tipo de usuário foi encontrado
            if (tipoUsuarioBuscado != null)
            {
                // Caso seja, retorna os dados buscados e um status code 200 - Ok
                return Ok(tipoUsuarioBuscado);
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum tipo de usuário encontrado para o identificador informado");
        }

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto tipoUsuarioAtualizado que será atualizado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/TiposUsuario/1
        /// <response code="204">Sem retorno ao ser atualizado com sucesso</response>
        /// <response code="400">Erro em alguma parte da requisição</response>
        /// <response code="401">Se o usuário não estiver logado</response>
        /// <response code="403">Se o usuário não tiver permissão para tal ação</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Put(int id, TiposUsuariosDomain tipoUsuarioAtualizado)
        {
            // Cria um objeto tipoUsuarioBuscado que irá receber o tipo de usuário buscado no banco de dados
            TiposUsuariosDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            // Verifica se algum tipo de usuário foi encontrado
            if (tipoUsuarioBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .Atualizar();
                    _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna BadRequest e o erro
                    return BadRequest(erro);
                }

            }

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para representar que houve erro
            return NotFound
                (
                    new
                    {
                        mensagem = "Tipo de usuário não encontrado",
                        erro = true
                    }
                );
        }

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        /// <returns>Retorna um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/TiposUsuario/1
        /// <response code="200">Se a requisição ocorrer corretamente</response>
        /// <response code="400">Erro em alguma parte da requisição</response>
        /// <response code="401">Se o usuário não estiver logado</response>
        /// <response code="403">Se o usuário não tiver permissão para tal ação</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Delete(int id)
        {
            // Cria um objeto tipoUsuarioBuscado que irá receber o tipo de usuário buscado no banco de dados
            TiposUsuariosDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            // Verifica se o tipo de usuário foi encontrado
            if (tipoUsuarioBuscado != null)
            {
                // Caso seja, faz a chamada para o método .Deletar()
                _tipoUsuarioRepository.Deletar(id);

                // e retorna um status code 200 - Ok com uma mensagem de sucesso
                return Ok($"O tipo de usuário {id} foi deletado com sucesso!");
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum tipo de usuário encontrado para o identificador informado");
        }
    }
}