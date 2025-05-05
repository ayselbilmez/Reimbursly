using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reimbursly.Application.DTOs.PaymentMethod;
using Reimbursly.Application.Interfaces;
using Reimbursly.Shared.Responses;

namespace Reimbursly.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentMethodController : ControllerBase
{
    private readonly IPaymentMethodService _service;

    public PaymentMethodController(IPaymentMethodService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(ApiResponse<List<PaymentMethodViewDto>>.Ok(result));
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null
            ? NotFound(ApiResponse<string>.Fail("Payment method not found."))
            : Ok(ApiResponse<PaymentMethodViewDto>.Ok(result));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CreatePaymentMethodDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok(ApiResponse<string>.Ok("Payment method created successfully."));
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePaymentMethodDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return Ok(ApiResponse<string>.Ok("Payment method updated successfully."));
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok(ApiResponse<string>.Ok("Payment method deleted successfully."));
    }
}
