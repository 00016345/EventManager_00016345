using EventManager_00016345.Attendees.DTOs;
using EventManager_00016345.Attendees.Interfaces;
using EventManager_00016345.Events.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EventManager_00016345.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AttendeesController :  ControllerBase
{
    private readonly IAttendeesService attendeesService;

    public AttendeesController(IAttendeesService attendeesService)
    {
        this.attendeesService = attendeesService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AttendeeForCreationDto dto)
    {
        var entity = await this.attendeesService.AddAsync(dto);
        return Ok(entity);
    }

    // DELETE: api/Event/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletAsync(int id)
    {
        var entity = await this.attendeesService.RemoveAsync(id);
        return Ok(entity);
    }

    // GET: api/Event
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var entities = await this.attendeesService.RetrieveAllAsync();
        return Ok(entities);
    }

    // GET: api/Event/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var entity = await this.attendeesService.RetrieveByIdAsync(id);
        return Ok(entity);
    }

    // PUT: api/Event/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] AttendeeForUpdateDto dto)
    {
        var entity = await this.attendeesService.UpdateAsync(id, dto);
        return Ok(entity);
    }

}
