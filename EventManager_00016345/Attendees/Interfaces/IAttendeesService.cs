using EventManager_00016345.Attendees.DTOs;

namespace EventManager_00016345.Attendees.Interfaces;

public interface IAttendeesService
{
    public Task<bool> AddAsync(AttendeeForCreationDto dto);
    public Task<bool> RemoveAsync(int id);
    public Task<bool> UpdateAsync(int id, AttendeeForUpdateDto dto);
    public Task<AttendeeForResultDto> RetrieveByIdAsync(int id);
    public Task<IEnumerable<AttendeeForResultDto>> RetrieveAllAsync();

}
