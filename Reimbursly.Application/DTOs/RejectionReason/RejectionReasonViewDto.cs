namespace Reimbursly.Application.DTOs.RejectionReason;

public class RejectionReasonViewDto
{
    public Guid Id { get; set; }
    public Guid ExpenseId { get; set; }
    public Guid ApproverId { get; set; }
    public string ApproverFullName { get; set; }
    public string Reason { get; set; }
    public DateTime RejectedAt { get; set; }
}
