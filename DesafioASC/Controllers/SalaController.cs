using DesafioASC.Application.UseCases.Sala.Commands;
using DesafioASC.Application.UseCases.Sala.Queries;
using DesafioASC.Domain.Entities;
using DesafioASC.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioASC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public SalaController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        /// <summary>
        /// Cadastra uma nova sala.
        /// </summary>
        /// <param name="command">Dados da sala a serem cadastrados.</param>
        /// <returns>A sala cadastrada.</returns>
        /// <response code="201">Retorna a sala recém-criada.</response>
        /// <response code="400">Se os dados da sala forem inválidos.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Sala), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateSalaCommand command)
        {
            await _dispatcher.Dispatch(command);

            return CreatedAtAction(nameof(GetById), new { id = command.Id }, command);
        }

        ///<summary>
        /// Atualiza uma sala
        ///</summary>
        /// <param name="command">Dados da sala a serem atualizados.</param>
        /// <response code="204">Atualizou a sala.</response>
        /// <response code="400">Se os dados da sala forem inválidos.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Sala), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSalaCommand command)
        {
            if (id != command.Id)
                return BadRequest("O ID da rota não confere com o ID do corpo da requisição.");

            await _dispatcher.Dispatch(command);
            return NoContent();
        }

        ///<summary>
        /// Remove uma sala
        ///</summary>
        /// <param name="id">Id da sala que vai ser removida.</param>
        /// <response code="204">Removeu a sala.</response>
        /// <response code="400">Se o Id da sala for inválido.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteSalaCommand { Id = id };
            await _dispatcher.Dispatch(command);
            return NoContent();
        }

        ///<summary>
        /// Busca uma sala pelo ID.
        ///</summary>
        /// <returns>A sala encontrada.</returns>
        /// <response code="200">Retorna a sala.</response>
        /// <response code="400">Se a sala não existir no banco.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Sala), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetSalaByIdQuery { Id = id };
            var result = await _dispatcher.Dispatch<GetSalaByIdQuery, Sala?>(query);
            return result is not null ? Ok(result) : NotFound();
        }

        ///<summary>
        /// Busca todas as salas
        ///</summary>
        /// <returns>A sala encontrada.</returns>
        /// <response code="200">Retorna todas as sala do banco.</response>
        [HttpGet]
        [ProducesResponseType(typeof(Sala), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSalaQuery();
            var result = await _dispatcher.Dispatch<GetAllSalaQuery, List<Sala>?>(query);
            return result is not null ? Ok(result) : NotFound();
        }
    }
}
