using FluentValidation;
using Reimbursly.Application.DTOs.Expense;

namespace Reimbursly.Application.Validators;

public class CreateExpenseDtoValidator : AbstractValidator<CreateExpenseDto>
{
    public CreateExpenseDtoValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Açıklama alanı boş olamaz.")
            .MaximumLength(500).WithMessage("Açıklama 500 karakteri geçemez.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Tutar 0'dan büyük olmalıdır.");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Kategori seçilmelidir.");

        RuleFor(x => x.PaymentMethodId)
            .NotEmpty().WithMessage("Ödeme yöntemi seçilmelidir.");

        RuleFor(x => x.LocationId)
            .NotEmpty().WithMessage("Lokasyon bilgisi seçilmelidir.");

        RuleFor(x => x.ReceiptFile)
            .NotNull().WithMessage("Fiş/fatura yüklenmelidir.");
    }
}
