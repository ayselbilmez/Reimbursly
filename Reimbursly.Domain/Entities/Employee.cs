namespace Reimbursly.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public string IBAN { get; set; }

    public Guid RoleId { get; set; }
    public Role Role { get; set; }

    public ICollection<Expense> Expenses { get; set; }
}
