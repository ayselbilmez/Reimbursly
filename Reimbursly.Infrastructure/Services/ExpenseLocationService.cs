using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reimbursly.Application.DTOs.ExpenseLocation;
using Reimbursly.Application.Interfaces;
using Reimbursly.Domain.Entities;
using Reimbursly.Persistence.DbContext;

namespace Reimbursly.Infrastructure.Services;

public class ExpenseLocationService : IExpenseLocationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ExpenseLocationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ExpenseLocationViewDto>> GetAllAsync()
    {
        var locations = await _unitOfWork.Repository<ExpenseLocation>().GetAllAsync();
        return _mapper.Map<List<ExpenseLocationViewDto>>(locations);
    }

    public async Task<ExpenseLocationViewDto> GetByIdAsync(Guid id)
    {
        var location = await _unitOfWork.Repository<ExpenseLocation>().GetByIdAsync(id);

        if (location == null)
            return null;

        return _mapper.Map<ExpenseLocationViewDto>(location);
    }

    public async Task CreateAsync(CreateExpenseLocationDto dto)
    {
        var location = _mapper.Map<ExpenseLocation>(dto);
        location.Id = Guid.NewGuid();

        await _unitOfWork.Repository<ExpenseLocation>().AddAsync(location);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(Guid id, UpdateExpenseLocationDto dto)
    {
        var location = await _unitOfWork.Repository<ExpenseLocation>().GetByIdAsync(id);
        if (location == null) return;

        location.Name = dto.Name;

        _unitOfWork.Repository<ExpenseLocation>().Update(location);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var location = await _unitOfWork.Repository<ExpenseLocation>().GetByIdAsync(id);
        if (location == null) return;

        _unitOfWork.Repository<ExpenseLocation>().Remove(location);
        await _unitOfWork.CompleteAsync();
    }
}
