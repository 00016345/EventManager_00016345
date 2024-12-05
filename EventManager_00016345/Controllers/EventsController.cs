using EventManager_00016345.Events.DTOs;
using EventManager_00016345.Events.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManager_00016345.Controllers;


[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IEventService eventService;

    public EventsController(IEventService eventService)
    {
        this.eventService = eventService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] EventForCreationDto dto)
    {
        var entity = await this.eventService.AddAsync(dto);
        return Ok(entity);
    }

    // DELETE: api/Event/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync(int id)
    {
        var entity = await this.eventService.RemoveAsync(id);
        return Ok(entity);
    }

    // GET: api/Event
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var events = await this.eventService.RetrieveAllAsync();
        return Ok(events);
    }

    // GET: api/Event/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var @event = await this.eventService.RetrieveByIdAsync(id);
        return Ok(@event);
    }

    // PUT: api/Event/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] EventForUpdateDto dto)
    {
        var entity = await this.eventService.UpdateAsync(id, dto);
        return Ok(entity);
    }
}
