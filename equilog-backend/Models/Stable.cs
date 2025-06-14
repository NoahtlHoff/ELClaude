﻿using System.ComponentModel.DataAnnotations;

namespace equilog_backend.Models;

public class Stable
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public required string Name { get; set; }

    [StringLength(50)]
    public required string Type { get; set; }

    [StringLength(50)]
    public required string County { get; set; }

    [StringLength(50)]
    public string? Address { get; set; }

    [StringLength(5)]
    public string? PostCode { get; set; }

    public int? BoxCount { get; set; }

    public virtual List<UserStable>? UserStables { get; set; }

    public virtual List<StableHorse>? StableHorses { get; set; }

    public virtual List<StablePost>? StablePosts { get; set; }

    public virtual WallPost? WallPost { get; set; }

    public virtual List<StableJoinRequest>? StableJoinRequests { get; set; }

    public virtual List<StableInvite>? StableInvites { get; set; }

}