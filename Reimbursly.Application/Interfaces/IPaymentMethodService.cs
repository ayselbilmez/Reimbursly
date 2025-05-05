using Reimbursly.Application.DTOs.PaymentMethod;

namespace Reimbursly.Application.Interfaces;

public interface IPaymentMethodService
{
    Task<List<PaymentMethodViewDto>> GetAllAsync();
    Task<PaymentMethodViewDto> GetByIdAsync(Guid id);
    Task CreateAsync(CreatePaymentMethodDto dto);
    Task UpdateAsync(Guid id, UpdatePaymentMethodDto dto);
    Task DeleteAsync(Guid id);
}
