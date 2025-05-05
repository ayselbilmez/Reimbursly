using Reimbursly.Application.DTOs.Role;

namespace Reimbursly.Application.Interfaces;

public interface IRoleService
{
    Task<List<RoleViewDto>> GetAllAsync();
    Task<RoleViewDto> GetByIdAsync(Guid id);
    Task CreateAsync(CreateRoleDto dto);
    Task UpdateAsync(Guid id, UpdateRoleDto dto);
    Task DeleteAsync(Guid id);
}
