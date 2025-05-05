using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reimbursly.Application.DTOs.Role;
using Reimbursly.Application.Interfaces;
using Reimbursly.Shared.Responses;

namespace Reimbursly.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _roleService.GetAllAsync();
        return Ok(ApiResponse<List<RoleViewDto>>.Ok(result));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _roleService.GetByIdAsync(id);
        return Ok(ApiResponse<RoleViewDto>.Ok(result));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
    {
        await _roleService.CreateAsync(dto);
        return Ok(ApiResponse<string>.Ok("Rol başarıyla oluşturuldu."));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRoleDto dto)
    {
        await _roleService.UpdateAsync(id, dto);
        return Ok(ApiResponse<string>.Ok("Rol güncellendi."));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _roleService.DeleteAsync(id);
        return Ok(ApiResponse<string>.Ok("Rol silindi."));
    }
}
