using EventManager.Models;

namespace EventManager_00016345.Data.IRepositories;

public interface IAttendeeRepository
{
    public Task<bool> InsertAsync(Attendee attendee);
    public Task<bool> UpdateAsync(Attendee attendee);
    public Task<bool> DeleteAsync(int id);
    public Task<Attendee> GetByIdAsync(int id);
    public IQueryable<Attendee> GetAll();
}
