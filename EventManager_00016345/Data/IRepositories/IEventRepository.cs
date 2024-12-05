using EventManager.Models;

namespace EventManager_00016345.Data.IRepositories;

public interface IEventRepository
{
    public Task<bool> InsertAsync(Event @event);
    public Task<bool> UpdateAsync(Event @event);
    public Task<bool > DeleteAsync(int id);
    public Task<Event> GetByIdAsync(int id);
    public IQueryable<Event> GetAll();
}
