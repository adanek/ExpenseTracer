using ExpenseTracer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseTracer.Persistence.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expenses");
            builder.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(e => e.Timestamp).IsRequired();
            builder.Property(e => e.Amount).HasColumnType("money");
            
        }
    }
}
