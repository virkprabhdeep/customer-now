using customer_now.Models;

namespace customer_now.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync();
        Task<Ticket> GetTicketByIdAsync(int id);
        Task AddTicketAsync(Ticket ticket);
        Task UpdateTicketAsync(Ticket ticket);
        Task DeleteTicketAsync(int id);
    }
}
