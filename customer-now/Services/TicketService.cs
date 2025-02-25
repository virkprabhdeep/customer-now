using customer_now.Models;
using customer_now.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace customer_now.Services
{
    public class TicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Task<IEnumerable<Ticket>> GetAllTickets() => _ticketRepository.GetTicketsAsync();
        public Task<Ticket> GetTicketById(int id) => _ticketRepository.GetTicketByIdAsync(id);
        public Task AddTicket(Ticket ticket) => _ticketRepository.AddTicketAsync(ticket);
        public Task UpdateTicket(Ticket ticket) => _ticketRepository.UpdateTicketAsync(ticket);
        public Task DeleteTicket(int id) => _ticketRepository.DeleteTicketAsync(id);
    }
}
