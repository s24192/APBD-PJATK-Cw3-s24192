using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class UpdateRoomDto
{
    [Required, MaxLength(20)]
    public string? Name { get; set; }
    [Required, MaxLength(20)]
    public string? BuildingCode { get; set; }
    [Required]
    public int? Floor { get; set; }
    
    public int Capacity { get; set; }
    
    public bool HasProjector { get; set; } = false;
    
    public bool IsActive { get; set; } = false;
}