using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reimbursly.Application.DTOs.RejectionReason;
using Reimbursly.Application.Interfaces;
using Reimbursly.Shared.Responses;

namespace Reimbursly.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RejectionReasonController : ControllerBase
{
    private readonly IRejectionReasonService _service;

    public RejectionReasonController(IRejectionReasonService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Manager,Director,CEO")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(ApiResponse<List<RejectionReasonViewDto>>.Ok(result));
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Manager,Director,CEO")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null
            ? NotFound(ApiResponse<string>.Fail("Rejection reason not found."))
            : Ok(ApiResponse<RejectionReasonViewDto>.Ok(result));
    }

    [HttpGet("by-expense/{expenseId}")]
    [Authorize(Roles = "Admin,Manager,Director,CEO")]
    public async Task<IActionResult> GetByExpense(Guid expenseId)
    {
        var result = await _service.GetByExpenseIdAsync(expenseId);
        return Ok(ApiResponse<List<RejectionReasonViewDto>>.Ok(result));
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Manager,Director,CEO")]
    public async Task<IActionResult> Create([FromBody] CreateRejectionReasonDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok(ApiResponse<string>.Ok("Rejection reason created successfully."));
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Manager,Director,CEO")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRejectionReasonDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return Ok(ApiResponse<string>.Ok("Rejection reason updated successfully."));
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Manager,Director,CEO")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok(ApiResponse<string>.Ok("Rejection reason deleted successfully."));
    }
}
