﻿namespace equilog_backend.DTOs.UserDTOs

{
    public class UserDto
    {
        public required int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }
        
        public required string Email { get; set; }
        
        public string? PhoneNumber { get; set; }
    }
}
