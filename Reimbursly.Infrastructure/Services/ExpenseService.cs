﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Reimbursly.Application.DTOs.Expense;
using Reimbursly.Application.DTOs.RejectionReason;
using Reimbursly.Application.Interfaces;
using Reimbursly.Domain.Entities;
using Reimbursly.Domain.Enums;
using System.Security.Claims;

namespace Reimbursly.Infrastructure.Services;

public class ExpenseService : IExpenseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ExpenseService(IUnitOfWork unitOfWork, IFileService fileService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _unitOfWork = unitOfWork;
        _fileService = fileService;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<ExpenseViewDto>> GetAllAsync()
    {
        var expenses = await _unitOfWork.Repository<Expense>()
                                        .FindAsync(e => e.Status == ExpenseStatus.Pending,
                                                    include: q => q
                                                        .Include(e => e.Category)
                                                        .Include(e => e.PaymentMethod)
                                                        .Include(e => e.Location)
                                                        .Include(e => e.ApprovedBy));

        return _mapper.Map<List<ExpenseViewDto>>(expenses);
    }

    public async Task<List<ExpenseViewDto>> GetHistoryAsync(Guid employeeId)
    {
        var expenses = await _unitOfWork.Repository<Expense>()
                                        .FindAsync(e => e.EmployeeId == employeeId && e.Status != ExpenseStatus.Pending,
                                                     include: q => q
                                                         .Include(e => e.Category)
                                                         .Include(e => e.PaymentMethod)
                                                         .Include(e => e.Location)
                                                         .Include(e => e.ApprovedBy));

        return _mapper.Map<List<ExpenseViewDto>>(expenses);
    }

    public async Task<ExpenseViewDto> GetByIdAsync(Guid id)
    {
        var expense = await _unitOfWork.Repository<Expense>()
                                        .GetAsync(e => e.Id == id,
                                            include: q => q
                                                .Include(e => e.Category)
                                                .Include(e => e.PaymentMethod)
                                                .Include(e => e.Location)
                                                .Include(e => e.ApprovedBy));
        return _mapper.Map<ExpenseViewDto>(expense);
    }

    public async Task CreateAsync(CreateExpenseDto dto)
    {
        var receiptPath = await _fileService.SaveReceiptAsync(dto.ReceiptFile);

        var expense = new Expense
        {
            Id = Guid.NewGuid(),
            Description = dto.Description,
            Amount = dto.Amount,
            CategoryId = dto.CategoryId,
            PaymentMethodId = dto.PaymentMethodId,
            LocationId = dto.LocationId,
            ReceiptPath = receiptPath,
            CreatedAt = DateTime.UtcNow,
            Status = ExpenseStatus.Pending,
            EmployeeId = dto.EmployeeId
        };

        await _unitOfWork.Repository<Expense>().AddAsync(expense);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(Guid id, UpdateExpenseDto dto)
    {
        var expense = await _unitOfWork.Repository<Expense>().GetByIdAsync(id);
        if (expense == null) return;

        if (dto.ReceiptFile != null)
        {
            var path = await _fileService.SaveReceiptAsync(dto.ReceiptFile);
            expense.ReceiptPath = path;
        }

        expense.Description = dto.Description;
        expense.Amount = dto.Amount;
        expense.CategoryId = dto.CategoryId;
        expense.PaymentMethodId = dto.PaymentMethodId;
        expense.LocationId = dto.LocationId;

        _unitOfWork.Repository<Expense>().Update(expense);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var expense = await _unitOfWork.Repository<Expense>().GetByIdAsync(id);
        if (expense == null) return;

        _unitOfWork.Repository<Expense>().Remove(expense);
        await _unitOfWork.CompleteAsync();
    }

    public async Task ApproveAsync(Guid expenseId)
    {
        var expense = await _unitOfWork.Repository<Expense>().GetByIdAsync(expenseId);
        if (expense == null) return;

        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null) return;

        var approverId = Guid.Parse(userIdClaim);

        expense.Status = ExpenseStatus.Approved;
        expense.ApprovedById = approverId;

        _unitOfWork.Repository<Expense>().Update(expense);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RejectAsync(RejectionReasonViewDto dto)
    {
        var expense = await _unitOfWork.Repository<Expense>().GetByIdAsync(dto.ExpenseId);
        if (expense == null) return;

        expense.Status = ExpenseStatus.Rejected;
        _unitOfWork.Repository<Expense>().Update(expense);

        var rejection = new RejectionReason
        {
            Id = Guid.NewGuid(),
            ExpenseId = dto.ExpenseId,
            ApproverId = dto.ApproverId,
            Reason = dto.Reason,
            RejectedAt = DateTime.UtcNow
        };

        await _unitOfWork.Repository<RejectionReason>().AddAsync(rejection);
        await _unitOfWork.CompleteAsync();
    }
}
