using Microsoft.AspNetCore.Mvc;
using customer_now.Services;
using customer_now.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace customer_now.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return Ok(await _ticketService.GetAllTickets());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _ticketService.GetTicketById(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitTicket([FromBody] Ticket ticket)
        {
            await _ticketService.AddTicket(ticket);
            return CreatedAtAction(nameof(GetTicket), new { id = ticket.TicketId }, ticket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] Ticket updatedTicket)
        {
            var ticket = await _ticketService.GetTicketById(id);
            if (ticket == null) return NotFound();

            ticket.Title = updatedTicket.Title;
            ticket.Description = updatedTicket.Description;
            ticket.Status = updatedTicket.Status;
            ticket.UpdatedAt = DateTime.UtcNow;

            await _ticketService.UpdateTicket(ticket);
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var ticket = await _ticketService.GetTicketById(id);
            if (ticket == null) return NotFound();

            ticket.Status = status;
            await _ticketService.UpdateTicket(ticket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _ticketService.GetTicketById(id);
            if (ticket == null) return NotFound();

            await _ticketService.DeleteTicket(id);
            return NoContent();
        }
    }
}
