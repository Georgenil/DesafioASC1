using DesafioASC.Application.UseCases.Reserva.Commands;
using DesafioASC.Application.UseCases.Reserva.Queries;
using DesafioASC.Domain.Entities;
using DesafioASC.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioASC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        private readonly IDispatcher _dispatcher;
        public ReservaController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        ///<summary>
        /// Cadastra uma nova reserva.
        ///</summary>
        /// <param name="command">Dados da reserva a serem cadastrados.</param>
        /// <returns>A reserva cadastrada.</returns>
        /// <response code="201">Retorna a reserva recém-criada.</response>
        /// <response code="400">Se os dados da reserva forem inválidos.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Reserva), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateReservaCommand command)
        {
            await _dispatcher.Dispatch(command);

            return CreatedAtAction(nameof(GetById), new { id = command.Id }, command);
        }

        ///<summary>
        /// Atualiza uma reserva
        ///</summary>
        /// <param name="command">Dados da reserva a serem atualizados.</param>
        /// <response code="204">Atualizou a reserva.</response>
        /// <response code="400">Se os dados da reserva forem inválidos.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Reserva), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateReservaCommand command)
        {
            if (id != command.Id)
                return BadRequest("O ID da rota não confere com o ID do corpo da requisição.");

            await _dispatcher.Dispatch(command);
            return NoContent();
        }

        ///<summary>
        /// Remove uma reserva
        ///</summary>
        /// <param name="id">Id da reserva que vai ser removida.</param>
        /// <response code="204">Removeu a reserva.</response>
        /// <response code="400">Se o Id da reserva for inválido.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteReservaCommand { Id = id };
            await _dispatcher.Dispatch(command);
            return NoContent();
        }

        ///<summary>
        /// Busca uma reserva através do ID
        ///</summary>
        /// <returns>A reserva encontrada.</returns>
        /// <response code="200">Retorna a reserva.</response>
        /// <response code="404">Se a reserva não existir no banco.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Reserva), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetReservaByIdQuery { Id = id };
            var result = await _dispatcher.Dispatch<GetReservaByIdQuery, Reserva?>(query);
            return result is not null ? Ok(result) : NotFound();
        }

        ///<summary>
        /// Busca todas as reservas
        ///</summary>
        /// <returns>As reservas encontradas.</returns>
        /// <response code="200">Retorna todas as reservas do banco.</response>
        /// <response code="404">Se as reservas não existirem no banco.</response>
        [HttpGet]
        [ProducesResponseType(typeof(Reserva), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllReservaQuery();
            var result = await _dispatcher.Dispatch<GetAllReservaQuery, List<Reserva>?>(query);
            return result is not null ? Ok(result) : NotFound();
        }
    }
}
