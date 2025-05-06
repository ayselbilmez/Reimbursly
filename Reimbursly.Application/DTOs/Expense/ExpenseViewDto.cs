namespace Reimbursly.Application.DTOs.Expense;

public class ExpenseViewDto
{
    public Guid Id { get; set; }
    public string Description { get; set; } = default!;
    public decimal Amount { get; set; }

    public string Category { get; set; } = default!;
    public string PaymentMethod { get; set; } = default!;
    public string Location { get; set; } = default!;

    public string Status { get; set; } = default!;
    public string? ApprovedByName { get; set; }
    public DateTime CreatedAt { get; set; }

    public string ReceiptPath { get; set; } = default!;
}
