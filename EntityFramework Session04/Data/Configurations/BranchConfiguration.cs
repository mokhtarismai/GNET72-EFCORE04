using EntityFramework_Session04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework_Session04.Data.Configurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("Branches");

        builder.HasKey(b => b.Code);
        builder.Property(b => b.Code).HasMaxLength(10);
        builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
        builder.Property(b => b.Address).IsRequired().HasMaxLength(200);
        builder.Property(b => b.PhoneNumber).IsRequired().HasMaxLength(20);

        
        builder.HasOne(b => b.Manager)
               .WithOne(m => m.Branch)
               .HasForeignKey<Manager>(m => m.BranchCode)
               .OnDelete(DeleteBehavior.Restrict);

        
        builder.HasMany(b => b.Accounts)
               .WithOne(a => a.Branch)
               .HasForeignKey(a => a.BranchCode)
               .OnDelete(DeleteBehavior.Restrict);

        
        builder.HasData(
            new Branch { Code = "CAI-01", Name = "Cairo Main Branch", Address = "12 Tahrir Square, Cairo", PhoneNumber = "0225550101" },
            new Branch { Code = "ALX-01", Name = "Alexandria Branch", Address = "45 Corniche Road, Alexandria", PhoneNumber = "0345550202" },
            new Branch { Code = "GIZ-01", Name = "Giza Branch", Address = "7 Pyramids Street, Giza", PhoneNumber = "0235550303" }
        );
    }
}