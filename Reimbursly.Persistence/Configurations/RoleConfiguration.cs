using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(r => r.Name)
                  .IsRequired()
                  .HasMaxLength(100);

        builder.Property(r => r.HierarchyLevel)
               .IsRequired();

        builder.HasData(
                new Role { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Assistant Specialist" },
                new Role { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Specialist" },
                new Role { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Manager" },
                new Role { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Director" },
                new Role { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "CEO" },
                new Role { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Name = "Admin" }
        );


    }
}
