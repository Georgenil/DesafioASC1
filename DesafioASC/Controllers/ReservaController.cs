using DesafioASC.Application.UseCases.Reserva.Commands;
using DesafioASC.Application.UseCases.Reserva.Queries;
using DesafioASC.Domain.Entities;
using DesafioASC.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioASC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        public ReservaController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        ///<Summary>
        /// Endpoint responsável pela criação da reserva.
        ///</Summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservaCommand command)
        {
            await _dispatcher.Dispatch(command);

            return CreatedAtAction(nameof(GetById), new { id = command.Id }, null);
        }

        ///<Summary>
        /// Endpoint responsável por buscar uma reserva pelo ID.
        ///</Summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetReservaByIdQuery { Id = id };
            var result = await _dispatcher.Dispatch<GetReservaByIdQuery, Reserva?>(query);
            return result is not null ? Ok(result) : NotFound();
        }
    }
}
