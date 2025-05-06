using AutoMapper;
using Reimbursly.Application.DTOs.PaymentMethod;
using Reimbursly.Application.Interfaces;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Infrastructure.Services;

public class PaymentMethodService : IPaymentMethodService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PaymentMethodService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<PaymentMethodViewDto>> GetAllAsync()
    {
        var methods = await _unitOfWork.Repository<PaymentMethod>().GetAllAsync();
        return _mapper.Map<List<PaymentMethodViewDto>>(methods);
    }

    public async Task<PaymentMethodViewDto> GetByIdAsync(Guid id)
    {
        var method = await _unitOfWork.Repository<PaymentMethod>().GetByIdAsync(id);

        if (method == null) return null;

        return _mapper.Map<PaymentMethodViewDto>(method);
    }

    public async Task CreateAsync(CreatePaymentMethodDto dto)
    {
        var method = _mapper.Map<PaymentMethod>(dto);
        method.Id = Guid.NewGuid();

        await _unitOfWork.Repository<PaymentMethod>().AddAsync(method);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(Guid id, UpdatePaymentMethodDto dto)
    {
        var method = await _unitOfWork.Repository<PaymentMethod>().GetByIdAsync(id);
        if (method == null) return;

        method.Name = dto.Name;

        _unitOfWork.Repository<PaymentMethod>().Update(method);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var method = await _unitOfWork.Repository<PaymentMethod>().GetByIdAsync(id);
        if (method == null) return;

        _unitOfWork.Repository<PaymentMethod>().Remove(method);
        await _unitOfWork.CompleteAsync();
    }
}
