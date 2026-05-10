using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class CreateRoomDto
{
    [Required, MaxLength(20)]
    public string? Name { get; set; }
    [Required, MaxLength(20)]
    public string? BuildingCode { get; set; }
    [Required]
    public int? Floor { get; set; }
    [Required]
    public int Capacity { get; set; }
    [Required]
    public bool HasProjector { get; set; } = false;
    [Required]
    public bool IsActive { get; set; } = false;
}