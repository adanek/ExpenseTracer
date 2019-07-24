using ExpenseTracer.Application.Interfaces;
using ExpenseTracer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracer.Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseService).Assembly);
        }
    }
}

