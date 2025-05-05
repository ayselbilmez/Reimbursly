using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reimbursly.Application.DTOs.Expense;
using Reimbursly.Application.DTOs.RejectionReason;
using Reimbursly.Application.Interfaces;
using Reimbursly.Shared.Responses;

namespace Reimbursly.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseService _service;

    public ExpenseController(IExpenseService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Manager,Director,CEO")]
    public async Task<IActionResult> GetAllPending()
    {
        var result = await _service.GetAllAsync();
        return Ok(ApiResponse<List<ExpenseViewDto>>.Ok(result));
    }

    [HttpGet("history/{employeeId}")]
    [Authorize]
    public async Task<IActionResult> GetHistory(Guid employeeId)
    {
        var result = await _service.GetHistoryAsync(employeeId);
        return Ok(ApiResponse<List<ExpenseViewDto>>.Ok(result));
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null
            ? NotFound(ApiResponse<string>.Fail("Expense not found."))
            : Ok(ApiResponse<ExpenseViewDto>.Ok(result));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromForm] CreateExpenseDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok(ApiResponse<string>.Ok("Expense created successfully."));
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, [FromForm] UpdateExpenseDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return Ok(ApiResponse<string>.Ok("Expense updated successfully."));
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok(ApiResponse<string>.Ok("Expense deleted successfully."));
    }

    [HttpPost("reject")]
    [Authorize(Roles = "Manager,Director,CEO,Admin")]
    public async Task<IActionResult> Reject([FromBody] RejectionReasonViewDto dto)
    {
        await _service.RejectAsync(dto);
        return Ok(ApiResponse<string>.Ok("Expense rejected."));
    }
}
