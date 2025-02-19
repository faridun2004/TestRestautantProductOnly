﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestRestautantProductOnly.CommandsQueries.Commands.Creates;
using TestRestautantProductOnly.CommandsQueries.Commands.Deletes;
using TestRestautantProductOnly.CommandsQueries.Commands.Updates;
using TestRestautantProductOnly.CommandsQueries.Queries.GetAll;
using TestRestautantProductOnly.CommandsQueries.Queries.GetByIds;

namespace TestRestautantProductOnly.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShipmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/shipments
        [HttpPost]
        public async Task<IActionResult> CreateShipment([FromBody] CreateShipmentCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetShipmentById), new { id = result }, result);
        }

        // PUT api/shipments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShipment(Guid id, [FromBody] UpdateShipmentCommand command)
        {
            if (id != command.ShipmentId)
            {
                return BadRequest("ID mismatch");
            }
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/shipments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipment(Guid id)
        {
            var command = new DeleteShipmentCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        // GET api/shipments/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipmentById(Guid id)
        {
            var query = new GetShipmentByIdQuery(id);
            var shipment = await _mediator.Send(query);
            return shipment != null ? Ok(shipment) : NotFound();
        }

        // GET api/shipments
        [HttpGet]
        public async Task<IActionResult> GetAllShipments()
        {
            var query = new GetShipmentsQuery();
            var shipments = await _mediator.Send(query);
            return Ok(shipments);
        }
    }
}
