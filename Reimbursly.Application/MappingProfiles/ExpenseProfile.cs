using AutoMapper;
using Reimbursly.Application.DTOs.Expense;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Application.MappingProfiles;

public class ExpenseProfile : Profile
{
    public ExpenseProfile()
    {
        CreateMap<Expense, ExpenseViewDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod.Name))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Name))
            .ForMember(dest => dest.ReceiptPath, opt => opt.MapFrom(src => src.ReceiptPath))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.ApprovedByName,
                opt => opt.MapFrom(src =>
                    src.ApprovedBy != null
                        ? src.ApprovedBy.FirstName + " " + src.ApprovedBy.LastName
                        : null));

        CreateMap<CreateExpenseDto, Expense>();
        CreateMap<UpdateExpenseDto, Expense>();

    }
}
