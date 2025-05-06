using Reimbursly.Application.DTOs.Expense;
using Reimbursly.Application.DTOs.RejectionReason;

namespace Reimbursly.Application.Interfaces;

public interface IExpenseService
{
    Task<List<ExpenseViewDto>> GetAllAsync(); // Pending olanlar
    Task<List<ExpenseViewDto>> GetHistoryAsync(Guid employeeId); // Geçmiş onaylı/red talepler
    Task<ExpenseViewDto> GetByIdAsync(Guid id);
    Task CreateAsync(CreateExpenseDto dto);
    Task UpdateAsync(Guid id, UpdateExpenseDto dto); // DTO ortak kullanıldı
    Task DeleteAsync(Guid id);
    Task ApproveAsync(Guid expenseId);
    Task RejectAsync(RejectionReasonViewDto dto);
}
