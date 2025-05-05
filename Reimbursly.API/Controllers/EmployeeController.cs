using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reimbursly.Application.DTOs.Employee;
using Reimbursly.Application.Interfaces;
using Reimbursly.Shared.Responses;

namespace Reimbursly.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    /// <summary>
    /// Yeni kullanıcı kaydı — Herkes erişebilir
    /// </summary>
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] CreateEmployeeDto dto)
    {
        await _employeeService.CreateAsync(dto);
        return Ok(ApiResponse<string>.Ok("Kayıt başarılı. Giriş yapabilirsiniz."));
    }

    /// <summary>
    /// Kullanıcı kendi bilgilerini günceller (rol hariç)
    /// </summary>
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateSelf(Guid id, [FromBody] UpdateEmployeeDto dto)
    {
        await _employeeService.UpdateAsync(id, dto);
        return Ok(ApiResponse<string>.Ok("Bilgileriniz güncellendi."));
    }

    /// <summary>
    /// Admin tarafından rol güncellemesi
    /// </summary>
    [HttpPut("update-role/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateRole(Guid id, [FromBody] UpdateEmployeeRoleDto dto)
    {
        await _employeeService.UpdateRoleAsync(id, dto.RoleName);
        return Ok(ApiResponse<string>.Ok("Kullanıcının rolü güncellendi."));
    }


    /// <summary>
    /// Tüm çalışanları getir — Sadece admin görebilir
    /// </summary>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _employeeService.GetAllAsync();
        return Ok(ApiResponse<List<EmployeeViewDto>>.Ok(result));
    }

    /// <summary>
    /// Belirli çalışanı getir — Sadece admin
    /// </summary>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _employeeService.GetByIdAsync(id);
        return Ok(ApiResponse<EmployeeViewDto>.Ok(result));
    }

    /// <summary>
    /// Çalışanı sil — Sadece admin
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _employeeService.DeleteAsync(id);
        return Ok(ApiResponse<string>.Ok("Kullanıcı silindi."));
    }
}
