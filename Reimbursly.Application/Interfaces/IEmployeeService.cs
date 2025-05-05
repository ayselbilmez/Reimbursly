using Reimbursly.Application.DTOs.Employee;

namespace Reimbursly.Application.Interfaces;

public interface IEmployeeService
{
    Task<List<EmployeeViewDto>> GetAllAsync();
    Task<EmployeeViewDto> GetByIdAsync(Guid id);
    Task CreateAsync(CreateEmployeeDto dto);
    Task UpdateAsync(Guid id, UpdateEmployeeDto dto);
    Task UpdateRoleAsync(Guid id, string roleName);
    Task DeleteAsync(Guid id);
}
