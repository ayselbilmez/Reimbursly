using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reimbursly.Domain.Entities;

namespace Reimbursly.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

        builder.Property(e => e.LastName)
               .IsRequired()
               .HasMaxLength(100);
        
        builder.Property(e => e.Email)
               .IsRequired()
               .HasMaxLength(150);

        builder.HasIndex(e => e.Email)
               .IsUnique();

        builder.Property(e => e.PasswordHash)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(e => e.IBAN)
               .IsRequired()
               .HasMaxLength(34);

        builder.HasOne(e => e.Role)
               .WithMany(r => r.Employees)
               .HasForeignKey(e => e.RoleId);

        builder.HasData(
            new Employee
            {
                Id = Guid.Parse("e1111111-1111-1111-1111-111111111111"),
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@company.com",
                PhoneNumber = "+905555555555",
                IBAN = "TR330006100519786457841326",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"), // Admin123!
                RoleId = Guid.Parse("66666666-6666-6666-6666-666666666666")
            },
            new Employee
            {
                Id = Guid.Parse("e2222222-2222-2222-2222-222222222222"),
                FirstName = "Demo",
                LastName = "User",
                Email = "demo@company.com",
                PhoneNumber = "+905544444444",
                IBAN = "TR120006200340000005672235",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Demo123!"), 
                RoleId = Guid.Parse("11111111-1111-1111-1111-111111111111") 
            }
        );
    }
}
