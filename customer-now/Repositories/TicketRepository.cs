using Microsoft.EntityFrameworkCore;
using customer_now.Data;
using customer_now.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace customer_now.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;
        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            return await _context.Tickets.AsNoTracking().FirstOrDefaultAsync(t => t.TicketId == id);
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTicketAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }
    }
}
