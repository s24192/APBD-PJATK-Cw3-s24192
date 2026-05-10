namespace WebApplication2.DTOs;

public class ReservationDto
{
    public int Id { get; set; }
    public int RoopmId { get; set; }
    public string OrganizerName { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Status { get; set; } = string.Empty;
}