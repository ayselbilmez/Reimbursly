using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Persistence.Configurations;

public class ExpenseCategoryConfiguration : IEntityTypeConfiguration<ExpenseCategory>
{
    public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasData(
             new ExpenseCategory { Id = Guid.Parse("a1111111-1111-1111-1111-111111111111"), Name = "Transportation" },
             new ExpenseCategory { Id = Guid.Parse("a2222222-2222-2222-2222-222222222222"), Name = "Accommodation" },
             new ExpenseCategory { Id = Guid.Parse("a3333333-3333-3333-3333-333333333333"), Name = "Meal" },
             new ExpenseCategory { Id = Guid.Parse("a4444444-4444-4444-4444-444444444444"), Name = "Refreshment" },
             new ExpenseCategory { Id = Guid.Parse("a5555555-5555-5555-5555-555555555555"), Name = "Office Supplies" },
             new ExpenseCategory { Id = Guid.Parse("a6666666-6666-6666-6666-666666666666"), Name = "Education" },
             new ExpenseCategory { Id = Guid.Parse("a7777777-7777-7777-7777-777777777777"), Name = "Representation Expenses" }
         );
    }
}
