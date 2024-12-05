using EventManager.Data;
using EventManager.Models;
using EventManager_00016345.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EventManager_00016345.Data.Repositories;

public class AttendeeRepository : IAttendeeRepository
{
    private readonly ApplicationDbContext dbContext;

    public AttendeeRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var attendee = await dbContext.Attendees.FirstOrDefaultAsync(e => e.Id == id);
        dbContext.Attendees.Remove(attendee);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public IQueryable<Attendee> GetAll()
    {
        return dbContext.Attendees;
    }

    public async Task<Attendee> GetByIdAsync(int id)
    {
        var attendee = await dbContext.Attendees.FirstOrDefaultAsync(e => e.Id == id);
        return attendee;
    }

    public async Task<bool> InsertAsync(Attendee attendee)
    {

        await dbContext.Attendees.AddAsync(attendee);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Attendee attendee)
    {

        dbContext.Attendees.Update(attendee);
        return await dbContext.SaveChangesAsync() > 0;
    }
}
