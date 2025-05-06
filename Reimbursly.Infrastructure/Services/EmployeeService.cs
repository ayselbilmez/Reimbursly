using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reimbursly.Application.DTOs.Employee;
using Reimbursly.Application.Interfaces;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Infrastructure.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<EmployeeViewDto>> GetAllAsync()
    {
        var employees = await _unitOfWork.Repository<Employee>()
            .FindAsync(e => true, 
            include: q => q.Include(e => e.Role));; 

        return _mapper.Map<List<EmployeeViewDto>>(employees);
    }

    public async Task<EmployeeViewDto> GetByIdAsync(Guid id)
    {
        var employee = await _unitOfWork.Repository<Employee>()
                                        .GetAsync(e => e.Id == id,
                                            include: q => q.Include(e => e.Role));

        if (employee == null)
            return null;

        return _mapper.Map<EmployeeViewDto>(employee);
    }

    public async Task CreateAsync(CreateEmployeeDto dto)
    {
        var defaultRole = await _unitOfWork.Repository<Role>()
            .FindAsync(r => r.Name == "Assistant Specialist");

        var role = defaultRole.FirstOrDefault();
        if (role == null)
            throw new Exception("Default role Assistant Specialist is not found.");

        var employee = _mapper.Map<Employee>(dto);
        employee.Id = Guid.NewGuid();
        employee.RoleId = role.Id;
        employee.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        await _unitOfWork.Repository<Employee>().AddAsync(employee);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(Guid id, UpdateEmployeeDto dto)
    {
        var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(id);
        if (employee == null) return;

        employee.LastName = dto.LastName;
        employee.PhoneNumber = dto.PhoneNumber;
        employee.IBAN = dto.IBAN;

        _unitOfWork.Repository<Employee>().Update(employee);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateRoleAsync(Guid employeeId, string roleName)
    {
        var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(employeeId);
        if (employee == null)
            throw new Exception("Employee cannot be found.");

        var roleList = await _unitOfWork.Repository<Role>().FindAsync(r => r.Name.ToLower() == roleName.ToLower());
        var role = roleList.FirstOrDefault();
        if (role == null)
            throw new Exception("Role cannot be found.");

        employee.RoleId = role.Id;

        _unitOfWork.Repository<Employee>().Update(employee);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(id);
        if (employee == null) return;

        _unitOfWork.Repository<Employee>().Remove(employee);
        await _unitOfWork.CompleteAsync();
    }
}
