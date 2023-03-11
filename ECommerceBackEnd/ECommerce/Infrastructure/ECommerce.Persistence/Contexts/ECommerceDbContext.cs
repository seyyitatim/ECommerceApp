using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Contexts
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // ChangeTracker: Entityler üzerinden yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir.
            // Update operasyonlarında track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                //switch (data.State)
                //{
                //    case EntityState.Modified:
                //        data.Entity.UpdateDate = DateTime.Now;
                //        break;
                //    case EntityState.Added:
                //        data.Entity.CreateDate = DateTime.Now;
                //        break;
                //    default:
                //        break;
                //}

                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateDate = DateTime.Now,
                    EntityState.Modified => data.Entity.CreateDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
