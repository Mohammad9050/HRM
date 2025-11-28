using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HRM.Domain.Entities;

namespace HRM.Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(e => e.Id);

            //builder.Property(e => e.FirstName)
            //       .IsRequired()
            //       .HasMaxLength(100);

            //builder.Property(e => e.LastName)
            //       .IsRequired()
            //       .HasMaxLength(100);

            //builder.Property(e => e.NationalCode)
            //       .IsRequired()
            //       .HasMaxLength(10);

            //builder.Property(e => e.HireDate)
            //       .IsRequired();

            //// Relation example
            //builder.HasOne(e => e.Department)
            //       .WithMany(d => d.Employees)
            //       .HasForeignKey(e => e.DepartmentId)
            //       .OnDelete(DeleteBehavior.Restrict);

            //// Indexes
            //builder.HasIndex(e => e.NationalCode)
            //       .IsUnique();
        }
    }
}
