using AutoMapper;
using Reimbursly.Application.DTOs.RejectionReason;
using Reimbursly.Application.Interfaces;
using Reimbursly.Domain.Entities;
using Reimbursly.Domain.Enums;

namespace Reimbursly.Infrastructure.Services;

public class RejectionReasonService : IRejectionReasonService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RejectionReasonService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<RejectionReasonViewDto>> GetAllAsync()
    {
        var rejections = await _unitOfWork.Repository<RejectionReason>().GetAllAsync();
        return _mapper.Map<List<RejectionReasonViewDto>>(rejections);
    }

    public async Task<List<RejectionReasonViewDto>> GetByExpenseIdAsync(Guid expenseId)
    {
        var rejections = await _unitOfWork.Repository<RejectionReason>()
            .FindAsync(r => r.ExpenseId == expenseId);

        return _mapper.Map<List<RejectionReasonViewDto>>(rejections);
    }

    public async Task<RejectionReasonViewDto> GetByIdAsync(Guid id)
    {
        var rejection = await _unitOfWork.Repository<RejectionReason>().GetByIdAsync(id);
        return _mapper.Map<RejectionReasonViewDto>(rejection);
    }

    public async Task CreateAsync(CreateRejectionReasonDto dto)
    {
        var expense = await _unitOfWork.Repository<Expense>().GetByIdAsync(dto.ExpenseId);
        if (expense == null) return;

        expense.Status = ExpenseStatus.Rejected;
        _unitOfWork.Repository<Expense>().Update(expense);

        var rejection = _mapper.Map<RejectionReason>(dto);
        rejection.Id = Guid.NewGuid();
        rejection.RejectedAt = DateTime.UtcNow;

        await _unitOfWork.Repository<RejectionReason>().AddAsync(rejection);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(Guid id, UpdateRejectionReasonDto dto)
    {
        var rejection = await _unitOfWork.Repository<RejectionReason>().GetByIdAsync(id);
        if (rejection == null) return;

        rejection.Reason = dto.Reason;

        _unitOfWork.Repository<RejectionReason>().Update(rejection);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var rejection = await _unitOfWork.Repository<RejectionReason>().GetByIdAsync(id);
        if (rejection == null) return;

        _unitOfWork.Repository<RejectionReason>().Remove(rejection);
        await _unitOfWork.CompleteAsync();
    }
}
