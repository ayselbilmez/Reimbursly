using AutoMapper;
using Reimbursly.Application.DTOs.ExpenseCategory;
using Reimbursly.Application.Interfaces;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Infrastructure.Services;

public class ExpenseCategoryService : IExpenseCategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ExpenseCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ExpenseCategoryViewDto>> GetAllAsync()
    {
        var categories = await _unitOfWork.Repository<ExpenseCategory>().GetAllAsync();
        return _mapper.Map<List<ExpenseCategoryViewDto>>(categories);
    }

    public async Task<ExpenseCategoryViewDto> GetByIdAsync(Guid id)
    {
        var category = await _unitOfWork.Repository<ExpenseCategory>().GetByIdAsync(id);
        
        if (category == null)
            return null;
       
        return _mapper.Map<ExpenseCategoryViewDto>(category);
    }

    public async Task CreateAsync(CreateExpenseCategoryDto dto)
    {
        var category = _mapper.Map<ExpenseCategory>(dto);
        category.Id = Guid.NewGuid();

        await _unitOfWork.Repository<ExpenseCategory>().AddAsync(category);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(Guid id, UpdateExpenseCategoryDto dto)
    {
        var category = await _unitOfWork.Repository<ExpenseCategory>().GetByIdAsync(id);
        if (category == null) return;

        category.Name = dto.Name;

        _unitOfWork.Repository<ExpenseCategory>().Update(category);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await _unitOfWork.Repository<ExpenseCategory>().GetByIdAsync(id);
        if (category == null) return;

        _unitOfWork.Repository<ExpenseCategory>().Remove(category);
        await _unitOfWork.CompleteAsync();
    }
}
