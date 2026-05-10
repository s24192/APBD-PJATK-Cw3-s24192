namespace WebApplication2.Models;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BuildingCode { get; set; } = string.Empty;
    public int Floor { get; set; }
    public int Capacity { get; set; }
    public bool HasProjector { get; set; } = false;
    public bool IsActive { get; set; } = false;
    
    
    
    
    
    
    
    public static List<Room> Rooms =
    [
        new ()
        {
            Id = 1,
            Name = "cos",
            BuildingCode = "A1",
            Floor = 2,
            Capacity = 30
        },
        new ()
        {
            Id = 2,
            Name = "asd",
            BuildingCode = "A1",
            Floor = 3,
            Capacity = 10
        },
        new ()
        {
            Id = 3,
            Name = "zxc",
            BuildingCode = "B2",
            Floor = 0,
            Capacity = 20,
            HasProjector = true
        }
    ];
}