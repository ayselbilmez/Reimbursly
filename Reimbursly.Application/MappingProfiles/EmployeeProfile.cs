using AutoMapper;
using Reimbursly.Application.DTOs.Employee;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Application.MappingProfiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeViewDto>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));

        CreateMap<CreateEmployeeDto, Employee>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));

        CreateMap<UpdateEmployeeDto, Employee>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
