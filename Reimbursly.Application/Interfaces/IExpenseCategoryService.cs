using Reimbursly.Application.DTOs.ExpenseCategory;

namespace Reimbursly.Application.Interfaces;

public interface IExpenseCategoryService
{
    Task<List<ExpenseCategoryViewDto>> GetAllAsync();
    Task<ExpenseCategoryViewDto> GetByIdAsync(Guid id);
    Task CreateAsync(CreateExpenseCategoryDto dto);
    Task UpdateAsync(Guid id, UpdateExpenseCategoryDto dto);
    Task DeleteAsync(Guid id);
}
