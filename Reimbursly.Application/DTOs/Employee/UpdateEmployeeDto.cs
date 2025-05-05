namespace Reimbursly.Application.DTOs.Employee;

public class UpdateEmployeeDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string IBAN { get; set; } = default!;
}
