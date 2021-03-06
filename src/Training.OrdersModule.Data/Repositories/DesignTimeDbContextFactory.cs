using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Training.OrdersModule.Data.Repositories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TrainingOrderDbContext>
    {
        public TrainingOrderDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TrainingOrderDbContext>();

            builder.UseSqlServer("Data Source=(local);Initial Catalog=VirtoCommerce3;Persist Security Info=True;User ID=virto;Password=virto;MultipleActiveResultSets=True;Connect Timeout=30");

            return new TrainingOrderDbContext(builder.Options);
        }
    }
}
