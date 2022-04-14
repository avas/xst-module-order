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
            Name = nameof(CustomerOrderType);

            Field<BooleanGraphType>("loyaltyCalculated", resolve: context => ((TrainingOrder)context.Source?.Order!)?.LoyaltyCalculated ?? false);
            Field<StringGraphType>("pointsOperationId", resolve: context => ((TrainingOrder)context.Source?.Order!)?.PointsOperationId);
            Field<DecimalGraphType>("loyaltyPointsAmount", resolve: context => ((TrainingOrder)context.Source?.Order!)?.LoyaltyPointsAmount);
        }
    }
}
