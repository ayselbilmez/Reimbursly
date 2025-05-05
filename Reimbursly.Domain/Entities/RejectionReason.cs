namespace Reimbursly.Domain.Entities;

public class RejectionReason
{
    public Guid Id { get; set; }

    public Guid ExpenseId { get; set; }
    public Expense Expense { get; set; }

    public Guid ApproverId { get; set; }
    public Employee Approver { get; set; }

    public string Reason { get; set; }
    public DateTime RejectedAt { get; set; } = DateTime.UtcNow;
}
