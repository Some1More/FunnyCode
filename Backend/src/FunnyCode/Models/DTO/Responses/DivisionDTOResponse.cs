﻿namespace FunnyCode.Models.DTO.Responses;

/// <summary>
/// Response information for division request
/// </summary>
public class DivisionDTOResponse
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public List<SubDivisionsListDTOResponse> Subdivisions { get; set; } = new();
}
