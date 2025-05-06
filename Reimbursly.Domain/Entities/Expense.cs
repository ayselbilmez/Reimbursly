using Reimbursly.Domain.Enums;

namespace Reimbursly.Domain.Entities;

public class Expense
{
    public Guid Id { get; set; }

    // Relations
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public Guid CategoryId { get; set; }
    public ExpenseCategory Category { get; set; }

    public Guid PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

    public Guid LocationId { get; set; }
    public ExpenseLocation Location { get; set; }
    
    public ICollection<RejectionReason> Rejections { get; set; }
    
    // Basic Properties
    public string Description { get; set; }
    public decimal Amount { get; set; }

    public ExpenseStatus Status { get; set; } = ExpenseStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public Guid? ApprovedById { get; set; }
    public Employee? ApprovedBy { get; set; }

    // Uploaded file path
    public string ReceiptPath { get; set; } // example: "/receipts/abc.jpg"



}
