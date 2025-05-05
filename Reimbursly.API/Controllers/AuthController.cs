using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reimbursly.Application.DTOs.Login;
using Reimbursly.Application.Interfaces;
using Reimbursly.Shared.Responses;

namespace Reimbursly.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Kullanıcı giriş işlemi yapar ve JWT token döner.
    /// </summary>
    /// <param name="loginRequest">Email ve şifre bilgileri</param>
    /// <returns>JWT Token + kullanıcı bilgileri</returns>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
    {
        var result = await _authService.LoginAsync(loginRequest);

        if (result == null)
            return Unauthorized(ApiResponse<string>.Fail("Geçersiz e-posta veya şifre."));

        return Ok(ApiResponse<AuthResponseDto>.Ok(result, "Giriş başarılı."));
    }
}
