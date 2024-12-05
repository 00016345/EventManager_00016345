using EventManager.Data;
using EventManager.Models;
using EventManager_00016345.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EventManager_00016345.Data.Repositories;

public class EventRepository : IEventRepository
{
    private readonly ApplicationDbContext dbContext;

    public EventRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var @event = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);
        dbContext.Events.Remove(@event);
        return await dbContext.SaveChangesAsync()>0;
    }

    public IQueryable<Event> GetAll()
    {
        return dbContext.Events;
    }

    public async Task<Event> GetByIdAsync(int id)
    {
        var @event = await dbContext.Events.FirstOrDefaultAsync(e => e.Id==id);
        return @event;
    }

    public async Task<bool> InsertAsync(Event @event)
    {
        await dbContext.Events.AddAsync(@event);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Event @event)
    {
        dbContext.Events.Update(@event);
        return await dbContext.SaveChangesAsync() > 0;
    }
}
