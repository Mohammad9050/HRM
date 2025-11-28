using Microsoft.EntityFrameworkCore;
using HRM.Domain.Entities;

namespace HRM.Infrastructure.Persistence.Context
{
    public class HRMDbContext : DbContext
    {
        public HRMDbContext(DbContextOptions<HRMDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRMDbContext).Assembly);
        }
    }
}
