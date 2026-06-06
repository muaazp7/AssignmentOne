using System.ComponentModel.DataAnnotations;

namespace u23637707_HW01_API.Models
{
    public class Event
    {
        [Key]
        public Guid Event_Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public double TicketPricing { get; set; }
    }
}
        