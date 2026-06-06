namespace u23637707_HW01_API.Models
{
    public interface IRepo
    {
        Task<bool> SaveChangesAsync();
        void Add<T>(T entity) where T : class;
        Task<List<Event>> GetEventsAsync();
        Task<Event> AddEventAsync(Event campusEvent);
        Task<Event> UpdateEventAsync(Guid id, Event campusEvent);
        Task<Event> DeleteEventAsync(Guid id);
        Task<Event> GetEventByIdAsync(Guid id);
    }
}