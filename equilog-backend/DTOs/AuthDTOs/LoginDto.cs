﻿namespace equilog_backend.DTOs.AuthDTOs;

public class LoginDto
{
    public required string Email { get; set; }

    public required string Password { get; set; }
}