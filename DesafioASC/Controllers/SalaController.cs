using DesafioASC.Application.UseCases.Sala.Commands;
using DesafioASC.Application.UseCases.Sala.Queries;
using DesafioASC.Domain.Entities;
using DesafioASC.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioASC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public SalaController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        /// <summary>
        /// Cadastra uma nova sala.
        /// </summary>
        /// <param name="command">Dados da sala a ser cadastrada.</param>
        /// <returns>A sala cadastrada.</returns>
        /// <response code="201">Retorna a sala recém-criada.</response>
        /// <response code="400">Se os dados da sala forem inválidos.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Sala), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateSalaCommand command)
        {
            await _dispatcher.Dispatch(command);

            return CreatedAtAction(nameof(GetById), new { id = command.Id }, null);
        }

        ///<Summary>
        /// Busca uma sala pelo ID.
        ///</Summary>
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
    }
}
