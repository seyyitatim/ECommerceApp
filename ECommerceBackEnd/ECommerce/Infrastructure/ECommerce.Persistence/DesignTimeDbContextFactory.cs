using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECommerce.Persistence
{
    // Powershellden migration yapmak istediğimizde Contextimize ilgili ayarların gitmesini sağlayan method
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceDbContext>
    {
        public ECommerceDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ECommerceDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.GetConnectionString());

            return new ECommerceDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
