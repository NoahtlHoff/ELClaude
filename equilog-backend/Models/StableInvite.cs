﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace equilog_backend.Models;

public class StableInvite
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("User")]
    public required int UserIdFk { get; set; }
    public virtual User? User { get; set; }

    [ForeignKey("Stable")]
    public required int StableIdFk { get; set; }
    public virtual Stable? Stable { get; set; }
}