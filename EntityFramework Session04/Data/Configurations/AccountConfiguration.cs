using EntityFramework_Session04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework_Session04.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(a => a.AccountNumber);
        builder.Property(a => a.AccountNumber).HasMaxLength(20);
        builder.Property(a => a.CurrentBalance).HasColumnType("decimal(18,2)");
        builder.Property(a => a.AccountType).HasConversion<string>().HasMaxLength(20);
        builder.Property(a => a.BranchCode).IsRequired().HasMaxLength(10);

        
        builder.HasMany(a => a.Transactions)
               .WithOne(t => t.Account)
               .HasForeignKey(t => t.AccountNumber)
               .OnDelete(DeleteBehavior.Restrict); 
    }
}