using ExpenseTracer.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracer.Persistence
{
    public class DatabaseServiceFactory : DesignTimeDbContextFactoryBase<DatabaseService>
    {
        protected override DatabaseService CreateNewInstance(DbContextOptions<DatabaseService> options)
        {
            return new DatabaseService(options);
        }
    }
}
