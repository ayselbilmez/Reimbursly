namespace Reimbursly.Application.DTOs.Employee;

public class UpdateEmployeeDto
{
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string IBAN { get; set; } = default!;
}
