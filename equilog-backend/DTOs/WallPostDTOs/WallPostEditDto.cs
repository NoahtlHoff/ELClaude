﻿using System.ComponentModel.DataAnnotations;

namespace equilog_backend.DTOs.WallPostDTOs
{
    public class WallPostEditDto
    {
        [Required]
        public int StableIdFk { get; set; }

        public string? Title { get; set; }

        public string? Body { get; set; }
    }
}
