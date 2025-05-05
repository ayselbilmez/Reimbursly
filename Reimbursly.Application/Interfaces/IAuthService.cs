using Reimbursly.Application.DTOs.Login;

namespace Reimbursly.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequest);
}
