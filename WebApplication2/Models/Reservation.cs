namespace WebApplication2.Models;

public class Reservation
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string OrganizerName { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Status { get; set; } = string.Empty;

    public static List<Reservation> reservations =
    [
        new()
        {
            Id = 1,
            RoomId = 1,
            OrganizerName = "Test org",
            Topic = "Test topic",
            StartTime = DateTime.Now,
            EndTime = new DateTime(2027, 10, 2),
            Status = "In progress"
        },
        new()
        {
            Id = 2,
            RoomId = 3,
            OrganizerName = "Test org 2",
            Topic = "Test topic 2",
            StartTime = DateTime.Now,
            EndTime = new DateTime(2027, 11, 2),
            Status = "In progress"
        }
    ];
}