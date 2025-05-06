using AutoMapper;
using Reimbursly.Application.DTOs.Expense;
using Reimbursly.Application.DTOs.ExpenseCategory;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Application.MappingProfiles;

public class ExpenseCategoryProfile : Profile
{
    public ExpenseCategoryProfile()
    {
        CreateMap<ExpenseCategory, ExpenseCategoryViewDto>();
        CreateMap<CreateExpenseCategoryDto, ExpenseCategory>();
        CreateMap<UpdateExpenseCategoryDto, ExpenseCategory>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

    }
}
