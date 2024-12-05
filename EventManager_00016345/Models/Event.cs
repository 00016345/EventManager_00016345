using System;
using System.Collections.Generic;

namespace EventManager.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public ICollection<Attendee> Attendees { get; set; }
    }
}
