using Microsoft.AspNetCore.Mvc;
using PackingApp.Application.Commands;
using PackingApp.Application.DTO;
using PackingApp.Application.Queries;
using PackingApp.Shared.Abstractions.Commands;
using PackingApp.Shared.Abstractions.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackingApp.WebAPI.Controllers
{
    public class SuitcasesController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public SuitcasesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SuitcaseDto>> Get([FromRoute] GetSuitcase query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuitcaseDto>>> Get([FromQuery] FindSuitcases query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSuitcaseWithItems command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        [HttpPut("{packingListId}/items")]
        public async Task<IActionResult> Put([FromBody] AddSuitcaseItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpPut("{packingListId:guid}/items/{name}/pack")]
        public async Task<IActionResult> Put([FromBody] PackSuitcaseItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpDelete("{packingListId:guid}/items/{name}")]
        public async Task<IActionResult> Delete([FromBody] RemoveSuitcaseItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromBody] DeleteSuitcase command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
    }
}
