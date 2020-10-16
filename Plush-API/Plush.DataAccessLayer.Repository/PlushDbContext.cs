using Microsoft.EntityFrameworkCore;
using Plush.DataAccessLayer.Domain.Domain;

namespace Plush.DataAccessLayer.Repository
{
    public class PlushDbContext: DbContext
    {
        public PlushDbContext(DbContextOptions<PlushDbContext> context):base(context)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProviderDelivery> ProviderDeliveries { get; set; }
        public DbSet<Provider> Providers { get; set; }
    }
}
