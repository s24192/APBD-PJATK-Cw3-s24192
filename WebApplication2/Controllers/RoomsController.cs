using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Models;


namespace WebApplication2.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RoomsController : ControllerBase
{


    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(
            Room.Rooms
            .Select(room => new RoomDto
            {
                Id = room.Id,
                Name = room.Name,
                BuildingCode = room.BuildingCode,
                Floor = room.Floor,
                Capacity = room.Capacity,
                HasProjector = room.HasProjector,
                IsActive = room.IsActive
            })
        );
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var room = Room.Rooms.FirstOrDefault(e => e.Id == id);
        if (room is null)
        {
            return NotFound($"Unable to find a room with {id} id.");
        }
        
        return Ok(room);
    }

    [HttpGet("/api/rooms-query")]
    public IActionResult GetRoomsFromQuery([FromQuery] int? minCapacity, [FromQuery] bool? hasProjector, [FromQuery] bool? isActiveactiveOnly)
    {
        return Ok(
            Room.Rooms.Where(e => e.HasProjector == hasProjector && e.IsActive == isActiveactiveOnly && e.Capacity >= minCapacity)
                .Select(r => new
                {
                    Id = r.Id,
                    Name = r.Name,
                    BuildingCode = r.BuildingCode,
                    Floor = r.Floor,
                    Capacity = r.Capacity,
                    hasProjector = r.HasProjector,
                    isActive = r.IsActive
                })
            );
    }
    
    
    [HttpGet("/api/Rooms/building/{buildingCode}")]
    public IActionResult GetByBuildingCode([FromRoute] string buildingCode)
    {
        var room = Room.Rooms.FindAll(e => e.BuildingCode.Equals(buildingCode));
        if (room.Count == 0)
        {
            return NotFound($"Unable to find a rooms with {buildingCode} building code.");
        }
        
        return Ok(room);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateRoomDto dto)
    {
        var room = Room.Rooms.FirstOrDefault(e => e.Id == id);
        if (room is null)
        {
            return NotFound($"Unable to  find a room with {id} id.");
        }
        
        room.Name = dto.Name!;
        room.BuildingCode = dto.BuildingCode!;
        room.Floor = (int)dto.Floor!;
        room.HasProjector = dto.HasProjector;
        room.IsActive = dto.IsActive;
        
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var room = Room.Rooms.FirstOrDefault(e => e.Id == id);
        if (room is null)
        {
            return NotFound($"Unable to find a  room with {id} id.");
        }
        
        Room.Rooms.Remove(room);
        
        return NoContent();
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateRoomDto dto)
    {
        var room = new Room
        {
            Id = Room.Rooms.Max(e => e.Id) + 1,
            Name = dto.Name!,
            BuildingCode = dto.BuildingCode!,
            Floor = (int)dto.Floor!,
            Capacity = (int)dto.Capacity,
            HasProjector = dto.HasProjector,
            IsActive = dto.IsActive
        };
        
        Room.Rooms.Add(room);
        
        return Created($"api/Students/{room.Id}", room);
    }
}