using System;
using System.Linq;
using Training.OrdersModule.Core.Models;
using Training.OrdersModule.Data.Models;
using VirtoCommerce.OrdersModule.Core.Model.Search;
using VirtoCommerce.OrdersModule.Core.Services;
using VirtoCommerce.OrdersModule.Data.Model;
using VirtoCommerce.OrdersModule.Data.Repositories;
using VirtoCommerce.OrdersModule.Data.Services;
using VirtoCommerce.Platform.Core.Caching;
using VirtoCommerce.Platform.Core.Common;

namespace Training.OrdersModule.Data.Services
{
    public class TrainingOrderSearchService : CustomerOrderSearchService
    {
        public TrainingOrderSearchService(Func<IOrderRepository> repositoryFactory, ICustomerOrderService customerOrderService, IPlatformMemoryCache platformMemoryCache)
            : base(repositoryFactory, customerOrderService, platformMemoryCache)
        {
        }


        protected override IQueryable<CustomerOrderEntity> BuildQuery(IRepository repository, CustomerOrderSearchCriteria criteria)
        {
            var query = base.BuildQuery(repository, criteria);

            if (criteria is TrainingOrderSearchCriteria trainingCriteria)
            {
                var trainingQuery = query.OfType<TrainingOrderEntity>();

                if (trainingCriteria.LoyaltyCalculated != null)
                {
                    trainingQuery = trainingQuery.Where(x => x.LoyaltyCalculated == trainingCriteria.LoyaltyCalculated);
                }

                query = trainingQuery;
            }

            return query;
        }
    }
}
