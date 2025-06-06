﻿namespace Reimbursly.Domain.Entities;

public class ExpenseCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<Expense> Expenses { get; set; }
}
