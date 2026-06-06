using Microsoft.AspNetCore.Mvc;
using u23637707_HW01_API.Models;
using u23637707_HW01_API.ViewModels;

namespace u23637707_HW01_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampusBuzzController : ControllerBase
    {
        private readonly IRepo _repo;

        public CampusBuzzController(IRepo repo)
        {
            _repo = repo;
        }

        [HttpGet(Name = "GetAllEvents")]
        public async Task<IActionResult> FetchAllEvents()
        {
            var result = await _repo.GetEventsAsync();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<IActionResult> FetchEventById(Guid id)
        {
            var campusEvent = await _repo.GetEventByIdAsync(id);
            if (campusEvent == null)
                return NotFound();
            return Ok(campusEvent);
        }

        [HttpPost(Name = "AddEvent")]
        public async Task<IActionResult> CreateEvent([FromBody] EventVM eventVM)
        {
            var newEvent = new Event
            {
                Event_Id = Guid.NewGuid(),
                Title = eventVM.Title,
                Location = eventVM.Location,
                TicketPricing = eventVM.TicketPricing
            };
            var created = await _repo.AddEventAsync(newEvent);
            return Ok(created);
        }

        [HttpPut("{id}", Name = "UpdateEvent")]
        public async Task<IActionResult> ModifyEvent(Guid id, [FromBody] EventVM eventVM)
        {
            var eventDetails = new Event
            {
                Title = eventVM.Title,
                Location = eventVM.Location,
                TicketPricing = eventVM.TicketPricing
            };
            var updated = await _repo.UpdateEventAsync(id, eventDetails);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        public async Task<IActionResult> RemoveEvent(Guid id)
        {
            var removed = await _repo.DeleteEventAsync(id);
            if (removed == null)
                return NotFound();
            return Ok(removed);
        }
    }
}