using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class CreateReservationDto
{
    
    [Required]
    public int? RoomId { get; set; }
    [Required]
    public string? OrganizerName { get; set; }
    [Required]
    public string? Topic { get; set; }
    [Required]
    public DateTime StartTime { get; set; } 
    [Required]
    public DateTime EndTime { get; set; } 
    [Required]
    public string? Status { get; set; }
}
