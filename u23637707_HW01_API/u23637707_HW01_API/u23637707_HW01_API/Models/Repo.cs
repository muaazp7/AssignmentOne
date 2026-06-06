using Microsoft.EntityFrameworkCore;

namespace u23637707_HW01_API.Models
{
    public class Repo : IRepo
    {
        private readonly AppDbContext _context;

        public Repo(AppDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            var events = await _context.Events.ToListAsync();
            events.Reverse();
            return events;
                
        }

        public async Task<Event> AddEventAsync(Event campusEvent)
        {
            _context.Events.Add(campusEvent);
            await _context.SaveChangesAsync();
            return campusEvent;
        }

        public async Task<Event> UpdateEventAsync(Guid id, Event campusEvent)
        {
            var existing = await _context.Events.FindAsync(id);
            if (existing == null) return null;

            existing.Title = campusEvent.Title;
            existing.Location = campusEvent.Location;
            existing.TicketPricing = campusEvent.TicketPricing;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Event> DeleteEventAsync(Guid id)
        {
            var existing = await _context.Events.FindAsync(id);
            if (existing == null) return null;

            _context.Events.Remove(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Event> GetEventByIdAsync(Guid id)
        {
            return await _context.Events.FindAsync(id);
        }
    }
}