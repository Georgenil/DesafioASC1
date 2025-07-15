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

        ///<Summary>
        /// Endpoint responsável pela criação da sala.
        ///</Summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSalaCommand command)
        {
            await _dispatcher.Dispatch(command);

            return CreatedAtAction(nameof(GetById), new { id = command.Id }, null);
        }

        ///<Summary>
        /// Endpoint responsável por buscar uma sala pelo ID.
        ///</Summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetSalaByIdQuery { Id = id };
            var result = await _dispatcher.Dispatch<GetSalaByIdQuery, Sala?>(query);
            return result is not null ? Ok(result) : NotFound();
        }
    }
}
