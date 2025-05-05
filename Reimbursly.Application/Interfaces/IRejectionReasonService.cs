using Reimbursly.Application.DTOs.RejectionReason;

namespace Reimbursly.Application.Interfaces;

public interface IRejectionReasonService
{
    Task<List<RejectionReasonViewDto>> GetAllAsync();
    Task<List<RejectionReasonViewDto>> GetByExpenseIdAsync(Guid expenseId);
    Task<RejectionReasonViewDto> GetByIdAsync(Guid id);
    Task CreateAsync(CreateRejectionReasonDto dto);
    Task UpdateAsync(Guid id, UpdateRejectionReasonDto dto);
    Task DeleteAsync(Guid id);
}
