using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Ticket.Domain.Interfaces;
using Ticket.Domain.Models;

namespace Ticket.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class TicketController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ITicketService _service;

        public TicketController(ILogger<TicketController> logger, ITicketService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Get all tickets
        /// </summary>
        /// <returns>A list of tickets</returns>
        /// <response code="201">Returns the list of tickets</response>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<TicketModel>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation($"[${nameof(TicketController)}] GetAll called {DateTimeOffset.UtcNow}");

            var result = await _service.GetAll();

            return Ok(result);
        }

        /// <summary>
        /// Get one ticket given an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A ticket</returns>
        /// <response code="201">Returns the ticket</response>
        /// <response code="400">If the ticket is null or an error occurred</response>  
        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(TicketModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"[${nameof(TicketController)}] GetById called {DateTimeOffset.UtcNow}");

            var result = await _service.GetById(id);

            return Ok(result);
        }

        /// <summary>
        /// Add one ticket given an id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///         "username": "ronny zapata",
        ///         "createdDate": "2021-04-28T23:02:50.939Z",
        ///         "updatedDate": "2021-04-28T23:02:50.939Z",
        ///         "status": true
        ///     }
        ///
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>A ticket</returns>
        /// <response code="201">Returns the new created ticket</response>
        /// <response code="400">If the ticket is null or an error occurred</response>  
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(TicketModel), (int) HttpStatusCode.Created)]
        public async Task<IActionResult> Insert(TicketModel model)
        {
            _logger.LogInformation($"[${nameof(TicketController)}] Insert called {DateTimeOffset.UtcNow}");

            var result = await _service.Insert(model);

            return StatusCode((int) HttpStatusCode.Created, result);
        }

        /// <summary>
        /// Update one ticket given an id
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A ticket</returns>
        /// <response code="201">Returns the ticket</response>
        /// <response code="400">If the ticket is null or an error occurred</response> 
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(TicketModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Update(TicketModel model)
        {
            _logger.LogInformation($"[${nameof(TicketController)}] Update called {DateTimeOffset.UtcNow}");

            var result = await _service.Update(model);

            return Ok(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Delete one ticket given an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A ticket</returns>
        /// <response code="201">Returns true if the ticket was deleted</response>
        /// <response code="400">If the ticket is null or an error occurred</response> 
        [HttpDelete("[action]/{id}")]
        [ProducesResponseType(typeof(bool), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"[${nameof(TicketController)}] Delete called {DateTimeOffset.UtcNow}");

            var result = await _service.Delete(id);

            return Ok(result);
        }
    }
}