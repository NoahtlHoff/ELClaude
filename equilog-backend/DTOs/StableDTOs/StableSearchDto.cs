﻿namespace equilog_backend.DTOs.StableDTOs

{
    public class StableSearchDto
    {
        public int Id { get; set; }
        
        public required string Name { get; set; }
        
        public string? Address { get; set; }
        
        public required string County { get; set; }
    }
}
