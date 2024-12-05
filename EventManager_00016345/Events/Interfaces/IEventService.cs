using EventManager_00016345.Events.DTOs;

namespace EventManager_00016345.Events.Interfaces;

public interface IEventService
{
    public Task<bool> AddAsync(EventForCreationDto dto);
    public Task<bool> RemoveAsync(int id);
    public Task<bool> UpdateAsync(int id, EventForUpdateDto dto);
    public Task<EventForResultDto> RetrieveByIdAsync(int id);
    public Task<IEnumerable<EventForResultDto>> RetrieveAllAsync();
}
