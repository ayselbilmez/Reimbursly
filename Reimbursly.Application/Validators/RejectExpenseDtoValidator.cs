using FluentValidation;
using Reimbursly.Application.DTOs.Expense;
using Reimbursly.Application.DTOs.RejectionReason;

namespace Reimbursly.Application.Validators;

public class RejectExpenseDtoValidator : AbstractValidator<CreateRejectionReasonDto>
{
    public RejectExpenseDtoValidator()
    {
        RuleFor(x => x.Reason)
            .NotEmpty().WithMessage("Red sebebi boş olamaz.")
            .MinimumLength(5).WithMessage("Red sebebi daha açıklayıcı olmalıdır.");
    }
}
