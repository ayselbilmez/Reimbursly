using AutoMapper;
using Reimbursly.Application.DTOs.ExpenseLocation;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Application.MappingProfiles;

public class ExpenseLocationProfile : Profile
{
    public ExpenseLocationProfile()
    {
        CreateMap<ExpenseLocation, ExpenseLocationViewDto>();
        CreateMap<CreateExpenseLocationDto, ExpenseLocation>();
        CreateMap<UpdateExpenseLocationDto, ExpenseLocation>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}

