using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Models
{
    public class Attendee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Email { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
