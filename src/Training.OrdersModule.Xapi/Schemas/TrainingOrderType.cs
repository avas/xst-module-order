using GraphQL.Types;
using Training.OrdersModule.Core.Models;
using VirtoCommerce.ExperienceApiModule.Core.Services;
using VirtoCommerce.ExperienceApiModule.XOrder.Schemas;

namespace Training.OrdersModule.Xapi.Schemas
{
    public class TrainingOrderType : CustomerOrderType
    {
        public TrainingOrderType(IDynamicPropertyResolverService dynamicPropertyResolverService)
            : base(dynamicPropertyResolverService)
        {
            Field<BooleanGraphType>("loyaltyCalculated", resolve: context => ((TrainingOrder)context.Source?.Order!)?.LoyaltyCalculated ?? false);
        }
    }
}
