﻿using EventManager.Models;

namespace EventManager_00016345.Events.DTOs;

public class EventForCreationDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public string Location { get; set; }
}