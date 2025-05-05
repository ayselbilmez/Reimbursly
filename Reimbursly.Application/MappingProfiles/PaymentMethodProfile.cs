using AutoMapper;
using Reimbursly.Application.DTOs.PaymentMethod;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Application.MappingProfiles;

public class PaymentMethodProfile : Profile
{
    public PaymentMethodProfile()
    {
        CreateMap<PaymentMethod, PaymentMethodViewDto>();
        CreateMap<CreatePaymentMethodDto, PaymentMethod>();
        CreateMap<UpdatePaymentMethodDto, PaymentMethod>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
