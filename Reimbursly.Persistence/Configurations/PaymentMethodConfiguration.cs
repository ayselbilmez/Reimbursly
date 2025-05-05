using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Persistence.Configurations;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasData(
            new PaymentMethod
            {
                Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                Name = "Cash"
            },
            new PaymentMethod
            {
                Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                Name = "Credit Card"
            }
        );
        
    }
}
