﻿namespace GymWorkDisclosed.DTOs;

public class BodypartDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    
    public BodypartDTO(Guid guid, string name)
    {
        Guid = guid;
        Name = name;
    }
}