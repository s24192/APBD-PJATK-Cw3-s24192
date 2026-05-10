using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllReservations()
    {
        return Ok(
            Reservation.reservations.Select(r => new
            {
                Id = r.Id,
                RoomId = r.RoomId,
                OrganizerName = r.OrganizerName,
                Topic = r.Topic,
                StartTime = r.StartTime,
                endTime = r.EndTime,
                Status = r.Status
            })
        );
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var reservation = Reservation.reservations.FirstOrDefault(r => r.Id == id);
        if (reservation is null)
        {
            return NotFound($"Unable to find a reservation with {id} id.");
        }
        
        return Ok(reservation);
    }
    
    [HttpGet("/api/Reservations-query")]
    public IActionResult GetRoomsFromQuery([FromQuery] DateTime? date, [FromQuery] string? status, [FromQuery] int? roomId)
    {
        return Ok(
            Reservation.reservations
                .Where(r => r.StartTime <= date && r.EndTime >= date && r.Status.Equals(status) && r.RoomId == roomId)
                .Select(r =>new
                {
                    Id = r.Id,
                    roomId = r.RoomId,
                    OrganizxerName = r.OrganizerName,
                    Topic = r.Topic,
                    StartTime = r.StartTime,
                    EmdTime = r.EndTime,
                    Status = r.Status
                })
                
                
        );
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] CreateReservationDto dto)
    {
        if (dto.OrganizerName == null || dto.Topic == null)
        {
            return BadRequest("The field OrganizerName and/or Topic are required.");
        }

        if (Room.Rooms.All(r => r.Id != dto.RoomId))
        {
                return BadRequest("There is no room with given id.");
        }

        if (!Room.Rooms.FirstOrDefault(r => r.Id == dto.RoomId)!.IsActive)
        {
            return BadRequest("Given room is marked as inactive.");
        }

        var reservation = new Reservation
        {
            Id = Reservation.reservations.Max(r => r.Id) + 1,
            RoomId = (int)dto.RoomId!,
            OrganizerName = dto.OrganizerName!,
            Topic = dto.Topic!,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            Status = dto.Status!
        };
        
        Reservation.reservations.Add(reservation);
        
        return Created($"api/Students/{reservation.Id}", reservation);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateReservationDto dto)
    {
        var reservation = Reservation.reservations.FirstOrDefault(e => e.Id == id);
        if (reservation is null)
        {
            return NotFound($"Unable to  find a reservation with {id} id.");
        }

        if (dto.OrganizerName == null || dto.Topic == null)
        {
            return BadRequest("The field OrganizerName and/or Topic are required.");
        }

        reservation.RoomId = (int)dto.RoomId!;
        reservation.OrganizerName = dto.OrganizerName!;
        reservation.Topic = dto.Topic!;
        reservation.StartTime = dto.StartTime;
        reservation.EndTime = dto.EndTime;
        reservation.Status = dto.Status;
        
        return Ok();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var reservation = Reservation.reservations.FirstOrDefault(e => e.Id == id);
        if (reservation is null)
        {
            return NotFound($"Unable to find a reservation with {id} id.");
        }
        
        Reservation.reservations.Remove(reservation);
        
        return NoContent();
    }
}