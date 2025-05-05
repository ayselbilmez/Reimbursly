using Microsoft.AspNetCore.Http;

namespace Reimbursly.Application.DTOs.Expense;

public class UpdateExpenseDto
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public Guid CategoryId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public Guid LocationId { get; set; }

    public IFormFile? ReceiptFile { get; set; }
}
