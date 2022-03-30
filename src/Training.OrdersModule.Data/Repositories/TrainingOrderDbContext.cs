using Microsoft.EntityFrameworkCore;
using Training.OrdersModule.Data.Models;
using VirtoCommerce.OrdersModule.Data.Repositories;

namespace Training.OrdersModule.Data.Repositories
{
    public class TrainingOrderDbContext : OrderDbContext
    {
        public TrainingOrderDbContext(DbContextOptions<TrainingOrderDbContext> options)
            : base(options)
        {
        }

        protected TrainingOrderDbContext(DbContextOptions options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrainingOrderEntity>().HasDiscriminator<string>("Discriminator");
            modelBuilder.Entity<TrainingOrderEntity>().Property("Discriminator").HasMaxLength(128).HasDefaultValue(nameof(TrainingOrderEntity));
        }
    }
}
