﻿namespace Reimbursly.Application.DTOs.Login;

public class AuthResponseDto
{
    public string Token { get; set; }
    public Guid UserId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}
