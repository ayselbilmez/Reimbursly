namespace Reimbursly.Application.DTOs.Employee;

public class EmployeeViewDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string IBAN { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
