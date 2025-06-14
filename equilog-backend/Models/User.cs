﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace equilog_backend.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(50)]
    public required string FirstName { get; set; }

    [StringLength(50)]
    public required string LastName { get; set; }

    [StringLength(254)]
    public required string Email { get; set; }

    [StringLength(254)]
    public string? EmergencyContact { get; set; }

    [StringLength(254)]
    public string? CoreInformation { get; set; }

    [StringLength(254)]
    public string? Description { get; set; }

    [StringLength(100)]
    public required string PasswordHash { get; set; }
    
    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    // Name of the blob in storage.
    [StringLength(50)]
    public string? ProfilePicture { get; set; }

    public virtual List<UserStable>? UserStables { get; set; }

    public virtual List<UserHorse>? UserHorses { get; set; }

    public virtual List<UserCalendarEvent>? UserEvents { get; set; }

    public virtual List<StablePost>? StablePost { get; set; }
    
    public virtual List<RefreshToken>? RefreshTokens { get; set; }
    
    public virtual List<StableJoinRequest>? StableJoinRequests { get; set; }
    
    public virtual List<StableInvite>? StableInvites { get; set; }
    
    public virtual List<UserComment>? UserComments { get; set; }
}