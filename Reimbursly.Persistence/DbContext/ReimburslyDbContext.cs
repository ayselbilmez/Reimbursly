using Microsoft.EntityFrameworkCore;
using Reimbursly.Domain.Entities;
using Reimbursly.Persistence.Configurations;

namespace Reimbursly.Persistence.DbContext;

public class ReimburslyDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ReimburslyDbContext(DbContextOptions<ReimburslyDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<ExpenseCategory> ExpenseCategories => Set<ExpenseCategory>();
    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
    public DbSet<ExpenseLocation> ExpenseLocations => Set<ExpenseLocation>();
    public DbSet<RejectionReason> RejectionReasons => Set<RejectionReason>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

        modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());

        modelBuilder.ApplyConfiguration(new ExpenseLocationConfiguration());

        modelBuilder.ApplyConfiguration(new ExpenseCategoryConfiguration());

        modelBuilder.ApplyConfiguration(new ExpenseConfiguration());

        modelBuilder.ApplyConfiguration(new ExpenseRejectionConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
