using Reimbursly.Application.DTOs.ExpenseLocation;

namespace Reimbursly.Application.Interfaces;

public interface IExpenseLocationService
{
    Task<List<ExpenseLocationViewDto>> GetAllAsync();
    Task<ExpenseLocationViewDto> GetByIdAsync(Guid id);
    Task CreateAsync(CreateExpenseLocationDto dto);
    Task UpdateAsync(Guid id, UpdateExpenseLocationDto dto);
    Task DeleteAsync(Guid id);
}
