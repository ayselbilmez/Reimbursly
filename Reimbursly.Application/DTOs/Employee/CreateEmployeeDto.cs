namespace Reimbursly.Application.DTOs.Employee;

public class CreateEmployeeDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Iban { get; set; } = default!;
}
