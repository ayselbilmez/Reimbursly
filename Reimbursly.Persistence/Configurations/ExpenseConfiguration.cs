using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reimbursly.Domain.Entities;
using Reimbursly.Domain.Enums;

namespace Reimbursly.Persistence.Configurations;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(e => e.Amount)
               .HasPrecision(18, 2)
               .IsRequired();

        builder.Property(e => e.ReceiptPath)
               .IsRequired();

        builder.Property(e => e.Status)
               .IsRequired();

        builder.Property(e => e.CreatedAt)
               .IsRequired();

        builder.HasOne(e => e.ApprovedBy)
               .WithMany()
               .HasForeignKey(e => e.ApprovedById)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Expense
            {
                Id = Guid.Parse("f1111111-1111-1111-1111-111111111111"),
                Description = "Taxi fare to client meeting",
                Amount = 150,
                CategoryId = Guid.Parse("a1111111-1111-1111-1111-111111111111"), // Ulaşım
                LocationId = Guid.Parse("b1111111-1111-1111-1111-111111111111"), // İstanbul Ofis
                PaymentMethodId = Guid.Parse("77777777-7777-7777-7777-777777777777"), // Nakit
                EmployeeId = Guid.Parse("e2222222-2222-2222-2222-222222222222"), // Demo User
                Status = ExpenseStatus.Pending,
                ReceiptPath = "uploads/receipts/receipt1.pdf",
                CreatedAt = DateTime.UtcNow
            },
            new Expense
            {
                Id = Guid.Parse("f2222222-2222-2222-2222-222222222222"),
                Description = "Hotel for business trip",
                Amount = 850,
                CategoryId = Guid.Parse("a2222222-2222-2222-2222-222222222222"), // Konaklama
                LocationId = Guid.Parse("b2222222-2222-2222-2222-222222222222"), // Ankara Ofis
                PaymentMethodId = Guid.Parse("88888888-8888-8888-8888-888888888888"), // Kredi Kartı
                EmployeeId = Guid.Parse("e2222222-2222-2222-2222-222222222222"),
                Status = ExpenseStatus.Approved,
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                ApprovedById = Guid.Parse("e1111111-1111-1111-1111-111111111111"),
                ReceiptPath = "uploads/receipts/receipt2.pdf"
            },
            new Expense
            {
                Id = Guid.Parse("f3333333-3333-3333-3333-333333333333"),
                Description = "Online course subscription",
                Amount = 500,
                CategoryId = Guid.Parse("a6666666-6666-6666-6666-666666666666"), // Eğitim
                LocationId = Guid.Parse("b3333333-3333-3333-3333-333333333333"), // Home Office
                PaymentMethodId = Guid.Parse("77777777-7777-7777-7777-777777777777"), // Nakit
                EmployeeId = Guid.Parse("e2222222-2222-2222-2222-222222222222"),
                Status = ExpenseStatus.Rejected,
                ReceiptPath = "uploads/receipts/receipt3.pdf",
                CreatedAt = DateTime.UtcNow
            }
        );
    }
}
