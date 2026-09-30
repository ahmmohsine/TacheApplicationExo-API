using Microsoft.AspNetCore.Mvc;
using TacheApp.Application.Commands.CreateTache;
using TacheApp.Application.Commands.DeleteTache;
using TacheApp.Application.Commands.UpdateTache;
using TacheApp.Application.DTOs;
using TacheApp.Application.Queries.GetAllTaches;
using TacheApp.Application.Queries.GetTacheById;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TacheApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacheController : ControllerBase
    {
        // GET: api/<TacheController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TacheDto>>> Get([FromServices] GetAllTachesQueryHandler handler, CancellationToken ct)
        {
            var result = await handler.HandleAsync(new GetAllTachesQuery(), ct);
            return Ok(result);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<TacheDto>> GetById(
        int id, [FromServices] GetTacheByIdQueryHandler handler, CancellationToken ct)
        {
            var result = await handler.HandleAsync(new GetTacheByIdQuery(id), ct);
            if (result == null) return NotFound();

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<TacheDto>> Create(
         [FromBody] CreateTacheInputDto input,
         [FromServices] CreateTacheCommandHandler handler, CancellationToken ct)
        {
            var result = await handler.HandleAsync(new CreateTacheCommand(input.Titre), ct);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,
            [FromBody] UpdateTacheInputDto input,
            [FromServices] UpdateTacheCommandHandler handler, CancellationToken token)
        {
            var result = (await handler.HandleAsync(new UpdateTacheCommand(id, input.Titre, input.Realisee), token));
            if (result) return Ok();
            return NotFound();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromServices] DeleteTacheCommandHandler handler, CancellationToken token)
        {
            bool success = await handler.HandleAsync(new DeleteTacheCommand(id), token);
            if (!success) return NotFound();
            return Ok();

        }
    }
}
