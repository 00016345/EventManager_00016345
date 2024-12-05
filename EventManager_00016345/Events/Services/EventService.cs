using AutoMapper;
using EventManager.Models;
using EventManager_00016345.Data.IRepositories;
using EventManager_00016345.Events.DTOs;
using EventManager_00016345.Events.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManager_00016345.Events.Services;

public class EventService : IEventService
{
    private readonly IMapper mapper;
    private readonly IEventRepository eventRepository;

    public EventService(IMapper mapper, IEventRepository eventRepository)
    {
        this.mapper = mapper;
        this.eventRepository = eventRepository;
    }

    public async Task<bool> AddAsync(EventForCreationDto dto)
    {
        var @event = await this.eventRepository.GetAll()
            .Where(e => e.Name.ToLower() ==  dto.Name.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (@event is not null)
            throw new Exception("Event already created");

        var mappedEvent = this.mapper.Map<Event>(dto);
        return await this.eventRepository.InsertAsync(mappedEvent);
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var @event = await this.eventRepository.GetAll()
            .Where (e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (@event is null)
            throw new Exception("Event not found");

        return await this.eventRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<EventForResultDto>> RetrieveAllAsync()
    {
        var events = await this.eventRepository.GetAll()
            .Include(e => e.Attendees)
            .AsNoTracking()
            .ToListAsync();

        return this.mapper.Map<IEnumerable<EventForResultDto>>(events);
    }

    public async Task<EventForResultDto> RetrieveByIdAsync(int id)
    {
        var @event = await this.eventRepository.GetAll()
            .Where (@event => @event.Id == id)
            .Include(e => e.Attendees)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (@event is null)
            throw new Exception("Event not found");

        return this.mapper.Map<EventForResultDto>(@event);
    }

    public async Task<bool> UpdateAsync(int id, EventForUpdateDto dto)
    {
        var @event = await this.eventRepository.GetAll()
            .Where(@event => @event.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (@event is null)
            throw new Exception("Event not found");

        var mappedEvent = this.mapper.Map(dto, @event);

        return await this.eventRepository.UpdateAsync(mappedEvent);
    }
}
