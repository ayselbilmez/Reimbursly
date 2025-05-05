namespace Reimbursly.Domain.Entities;

public class PaymentMethod
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<Expense> Expenses { get; set; }
}
