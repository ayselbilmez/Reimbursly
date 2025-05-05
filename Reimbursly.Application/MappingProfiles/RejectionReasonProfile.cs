using AutoMapper;
using Reimbursly.Application.DTOs.RejectionReason;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Application.MappingProfiles;

public class RejectionReasonProfile : Profile
{
    public RejectionReasonProfile()
    {
        CreateMap<RejectionReason, RejectionReasonViewDto>()
            .ForMember(dest => dest.ApproverFullName, opt => opt.MapFrom(src =>
                src.Approver.FirstName + " " + src.Approver.LastName));

        CreateMap<CreateRejectionReasonDto, RejectionReason>();
        CreateMap<UpdateRejectionReasonDto, RejectionReason>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
