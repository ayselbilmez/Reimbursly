using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reimbursly.Application.DTOs.ExpenseCategory;
using Reimbursly.Application.Interfaces;
using Reimbursly.Shared.Responses;

namespace Reimbursly.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseCategoryController : ControllerBase
{
    private readonly IExpenseCategoryService _service;

    public ExpenseCategoryController(IExpenseCategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(ApiResponse<List<ExpenseCategoryViewDto>>.Ok(result));
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null
            ? NotFound(ApiResponse<string>.Fail("Expense category not found."))
            : Ok(ApiResponse<ExpenseCategoryViewDto>.Ok(result));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CreateExpenseCategoryDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok(ApiResponse<string>.Ok("Expense category created successfully."));
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateExpenseCategoryDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return Ok(ApiResponse<string>.Ok("Expense category updated successfully."));
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok(ApiResponse<string>.Ok("Expense category deleted successfully."));
    }
}
