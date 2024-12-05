using EventManager.Models;
using EventManager_00016345.Attendees.DTOs;

namespace EventManager_00016345.Events.DTOs;

public class EventForResultDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public string Location { get; set; }
    public ICollection<AttendeeForResultDto> Attendees { get; set; }
}
