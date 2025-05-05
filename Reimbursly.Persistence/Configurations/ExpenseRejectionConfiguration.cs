using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Persistence.Configurations;

public class ExpenseRejectionConfiguration : IEntityTypeConfiguration<RejectionReason>
{
    public void Configure(EntityTypeBuilder<RejectionReason> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Expense)
               .WithMany(x => x.Rejections)
               .HasForeignKey(x => x.ExpenseId)
               .OnDelete(DeleteBehavior.Restrict); 

        builder.HasOne(x => x.Approver)
               .WithMany()
               .HasForeignKey(x => x.ApproverId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Reason)
               .IsRequired()
               .HasMaxLength(500);

        builder.HasData(
            new RejectionReason
            {
                Id = Guid.Parse("c1111111-1111-1111-1111-111111111111"),
                ExpenseId = Guid.Parse("f3333333-3333-3333-3333-333333333333"),
                ApproverId = Guid.Parse("e1111111-1111-1111-1111-111111111111"),
                Reason = "Missing receipt",
                RejectedAt = DateTime.UtcNow
            },
            new RejectionReason
            {
                Id = Guid.Parse("c2222222-2222-2222-2222-222222222222"),
                ExpenseId = Guid.Parse("f3333333-3333-3333-3333-333333333333"),
                ApproverId = Guid.Parse("e1111111-1111-1111-1111-111111111111"),
                Reason = "Exceeds budget",
                RejectedAt = DateTime.UtcNow
            },
            new RejectionReason
            {
                Id = Guid.Parse("c3333333-3333-3333-3333-333333333333"),
                ExpenseId = Guid.Parse("f3333333-3333-3333-3333-333333333333"),
                ApproverId = Guid.Parse("e1111111-1111-1111-1111-111111111111"),
                Reason = "Invalid category",
                RejectedAt = DateTime.UtcNow
            },
            new RejectionReason
            {
                Id = Guid.Parse("c4444444-4444-4444-4444-444444444444"),
                ExpenseId = Guid.Parse("f3333333-3333-3333-3333-333333333333"),
                ApproverId = Guid.Parse("e1111111-1111-1111-1111-111111111111"),
                Reason = "Insufficient details",
                RejectedAt = DateTime.UtcNow
            },
            new RejectionReason
            {
                Id = Guid.Parse("c5555555-5555-5555-5555-555555555555"),
                ExpenseId = Guid.Parse("f3333333-3333-3333-3333-333333333333"),
                ApproverId = Guid.Parse("e1111111-1111-1111-1111-111111111111"),
                Reason = "Duplicate entry",
                RejectedAt = DateTime.UtcNow
            }
        );      
    }
}
