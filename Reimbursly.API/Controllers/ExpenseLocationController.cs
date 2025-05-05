using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reimbursly.Application.DTOs.ExpenseLocation;
using Reimbursly.Application.Interfaces;
using Reimbursly.Shared.Responses;

namespace Reimbursly.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseLocationController : ControllerBase
{
    private readonly IExpenseLocationService _service;

    public ExpenseLocationController(IExpenseLocationService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(ApiResponse<List<ExpenseLocationViewDto>>.Ok(result));
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null
            ? NotFound(ApiResponse<string>.Fail("Location not found."))
            : Ok(ApiResponse<ExpenseLocationViewDto>.Ok(result));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CreateExpenseLocationDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok(ApiResponse<string>.Ok("Location created successfully."));
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateExpenseLocationDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return Ok(ApiResponse<string>.Ok("Location updated successfully."));
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok(ApiResponse<string>.Ok("Location deleted successfully."));
    }
}
