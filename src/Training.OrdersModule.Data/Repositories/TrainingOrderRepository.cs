using VirtoCommerce.OrdersModule.Data.Repositories;
using VirtoCommerce.Platform.Core.Domain;

namespace Training.OrdersModule.Data.Repositories
{
    public class TrainingOrderRepository : OrderRepository
    {
        public TrainingOrderRepository(TrainingOrderDbContext dbContext, IUnitOfWork unitOfWork = null)
            : base(dbContext, unitOfWork)
        {
        }
    }
}
