using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracer.Application.Interfaces;
using ExpenseTracer.Common.Dates;
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

    public class DatabaseInitializer
    {
        public static async Task Initialize(IDatabaseService context, IDateTimeProvider dateTimeProvider)
        {
            if (context.Expenses.Any())
            {
                return;
            }

            context.Expenses.AddRange(new[]
                {
                    new Expense()
                    {
                        Amount = 12.34m,
                        Timestamp = dateTimeProvider.Now
                    },

                    new Expense()
                    {
                        Amount = 23m,
                        Timestamp = dateTimeProvider.Now
                    }
                });

            await context.SaveChangesAsync(CancellationToken.None);

        }
    }
}

