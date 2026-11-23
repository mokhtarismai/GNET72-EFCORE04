using EntityFramework_Session04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework_Session04.Data.Configurations;

public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.ToTable("Managers");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.FullName).IsRequired().HasMaxLength(150);
        builder.Property(m => m.Email).IsRequired().HasMaxLength(200);
        builder.Property(m => m.PhoneNumber).IsRequired().HasMaxLength(20);
        builder.Property(m => m.BranchCode).IsRequired().HasMaxLength(10);

        builder.HasIndex(m => m.Email).IsUnique();
        builder.HasIndex(m => m.BranchCode).IsUnique();
        
        builder.HasData(
            new Manager { Id = 1, FullName = "Khaled Mansour", Email = "khaled.mansour@nationalbank.com", PhoneNumber = "01011111111", HireDate = new DateOnly(2015, 3, 1), BranchCode = "CAI-01" },
            new Manager { Id = 2, FullName = "Salma Hassan", Email = "salma.hassan@nationalbank.com", PhoneNumber = "01022222222", HireDate = new DateOnly(2018, 7, 15), BranchCode = "ALX-01" },
            new Manager { Id = 3, FullName = "Omar Fathy", Email = "omar.fathy@nationalbank.com", PhoneNumber = "01033333333", HireDate = new DateOnly(2020, 1, 10), BranchCode = "GIZ-01" }
        );
    }
}