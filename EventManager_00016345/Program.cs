using EventManager.Data;
using EventManager_00016345.Attendees.Interfaces;
using EventManager_00016345.Attendees.Services;
using EventManager_00016345.Data.IRepositories;
using EventManager_00016345.Data.Repositories;
using EventManager_00016345.Events.Interfaces;
using EventManager_00016345.Events.Services;
using EventManager_00016345.Mappers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<IEventRepository,EventRepository>();
builder.Services.AddScoped<IAttendeeRepository,AttendeeRepository>();

builder.Services.AddScoped<IEventService,EventService>();
builder.Services.AddScoped<IAttendeesService,AttendeeService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
