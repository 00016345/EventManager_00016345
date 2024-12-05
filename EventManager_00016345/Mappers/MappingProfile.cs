using AutoMapper;
using EventManager.Models;
using EventManager_00016345.Attendees.DTOs;
using EventManager_00016345.Events.DTOs;

namespace EventManager_00016345.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Attendee
        CreateMap<Attendee,AttendeeForCreationDto>().ReverseMap();
        CreateMap<Attendee, AttendeeForUpdateDto>().ReverseMap();
        CreateMap<Attendee, AttendeeForResultDto>().ReverseMap();

        // Events

        CreateMap<Event,EventForCreationDto>().ReverseMap();
        CreateMap<Event, EventForResultDto>().ReverseMap();
        CreateMap<Event, EventForUpdateDto>().ReverseMap();


    }
}
