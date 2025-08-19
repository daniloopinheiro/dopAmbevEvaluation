using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.Get;
using Ambev.DeveloperEvaluation.Application.Sales.ListSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [ApiController]
    [Route("api/sales")]
    public class SalesController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public SalesController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator; _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSale.CreateSaleRequest request, CancellationToken ct)
        {
            var cmd = _mapper.Map<CreateSaleCommand>(request);
            var result = await _mediator.Send(cmd, ct);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        {
            var result = await _mediator.Send(new GetSaleCommand(id), ct);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListSalesQuery query, CancellationToken ct)
        {
            var (data, total) = await _mediator.Send(query, ct);
            return Ok(new { total, data });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSale.UpdateSaleRequest request, CancellationToken ct)
        {
            var cmd = _mapper.Map<UpdateSaleCommand>(request) with { Id = id };
            var result = await _mediator.Send(cmd, ct);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        {
            await _mediator.Send(new DeleteSaleCommand(id), ct);
            return NoContent();
        }

        [HttpPost("{id:guid}/cancel")]
        public async Task<IActionResult> Cancel([FromRoute] Guid id, CancellationToken ct)
        {
            var result = await _mediator.Send(new CancelSaleCommand(id), ct);
            return Ok(result);
        }
    }
}
