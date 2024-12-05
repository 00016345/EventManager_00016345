using AutoMapper;
using EventManager.Models;
using EventManager_00016345.Attendees.DTOs;
using EventManager_00016345.Attendees.Interfaces;
using EventManager_00016345.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EventManager_00016345.Attendees.Services;

public class AttendeeService : IAttendeesService
{
    private readonly IAttendeeRepository attendeeRepository;
    private readonly IEventRepository eventRepository;
    private readonly IMapper mapper;

    public AttendeeService(IAttendeeRepository attendeeRepository, IEventRepository eventRepository, IMapper mapper)
    {
        this.attendeeRepository = attendeeRepository;
        this.eventRepository = eventRepository;
        this.mapper = mapper;
    }

    public async Task<bool> AddAsync(AttendeeForCreationDto dto)
    {
        var @event = await this.eventRepository.GetAll()
            .Where(e => e.Id == dto.EventId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (@event == null)
            throw new Exception("Event not found");

        var mappedAttendee = this.mapper.Map<Attendee>(dto);

        return await this.attendeeRepository.InsertAsync(mappedAttendee);
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var attendee = await this.attendeeRepository.GetAll()
            .Where(a => a.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (attendee == null)
            throw new Exception("Event not found");

        return await this.attendeeRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<AttendeeForResultDto>> RetrieveAllAsync()
    {
        var attendees = await this.attendeeRepository.GetAll()
            .AsNoTracking()
            .ToListAsync();

        return this.mapper.Map<IEnumerable<AttendeeForResultDto>>(attendees);
    }

    public async Task<AttendeeForResultDto> RetrieveByIdAsync(int id)
    {
        var attendee = await this.attendeeRepository.GetAll()
            .Where(a => a.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return this.mapper.Map<AttendeeForResultDto>(attendee);
    }

    public async Task<bool> UpdateAsync(int id, AttendeeForUpdateDto dto)
    {
        var attendee = await this.attendeeRepository.GetAll()
            .Where(a => a.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (attendee == null)
            throw new Exception("Attendee not found");

        var mappedAttendee = this.mapper.Map(dto, attendee);

        return await this.attendeeRepository.UpdateAsync(mappedAttendee);
    }
}
