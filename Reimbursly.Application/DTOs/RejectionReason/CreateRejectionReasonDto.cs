namespace Reimbursly.Application.DTOs.RejectionReason;

public class CreateRejectionReasonDto
{
    public Guid ExpenseId { get; set; }
    public Guid ApproverId { get; set; }
    public string Reason { get; set; }
}
