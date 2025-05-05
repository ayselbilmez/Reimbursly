using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Persistence.Configurations;

public class ExpenseLocationConfiguration : IEntityTypeConfiguration<ExpenseLocation>
{
    public void Configure(EntityTypeBuilder<ExpenseLocation> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasData(
             new ExpenseLocation { Id = Guid.Parse("b1111111-1111-1111-1111-111111111111"), Name = "İstanbul Office" },
             new ExpenseLocation { Id = Guid.Parse("b2222222-2222-2222-2222-222222222222"), Name = "Ankara Office" },
             new ExpenseLocation { Id = Guid.Parse("b3333333-3333-3333-3333-333333333333"), Name = "Home Office" },
             new ExpenseLocation { Id = Guid.Parse("b4444444-4444-4444-4444-444444444444"), Name = "Client Location" }
        );
    }
}
