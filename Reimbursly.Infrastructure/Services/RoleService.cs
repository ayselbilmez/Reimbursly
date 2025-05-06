using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reimbursly.Application.DTOs.Role;
using Reimbursly.Application.Interfaces;
using Reimbursly.Domain.Entities;
using Reimbursly.Persistence.DbContext;

namespace Reimbursly.Infrastructure.Services;

public class RoleService : IRoleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<RoleViewDto>> GetAllAsync()
    {
        var roles = await _unitOfWork.Repository<Role>().GetAllAsync();
        return _mapper.Map<List<RoleViewDto>>(roles);
    }

    public async Task<RoleViewDto> GetByIdAsync(Guid id)
    {
        var role = await _unitOfWork.Repository<Role>().GetByIdAsync(id);

        if (role == null) return null;

        return _mapper.Map<RoleViewDto>(role);
    }

    public async Task CreateAsync(CreateRoleDto dto)
    {
        var role = _mapper.Map<Role>(dto);
        role.Id = Guid.NewGuid();

        await _unitOfWork.Repository<Role>().AddAsync(role);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(Guid id, UpdateRoleDto dto)
    {
        var role = await _unitOfWork.Repository<Role>().GetByIdAsync(id);
        if (role == null) return;

        role.Name = dto.Name;
        _unitOfWork.Repository<Role>().Update(role);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var role = await _unitOfWork.Repository<Role>().GetByIdAsync(id);
        if (role == null) return;

        _unitOfWork.Repository<Role>().Remove(role);
        await _unitOfWork.CompleteAsync();
    }
}
