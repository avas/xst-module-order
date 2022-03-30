using GraphQL;
using GraphQL.Builders;
using VirtoCommerce.ExperienceApiModule.XOrder.Queries;

namespace Training.OrdersModule.Xapi.Queries
{
    public class TrainingSearchOrderQuery : SearchOrderQuery
    {
        public bool? LoyaltyCalculated { get; set; }

        public override void Map(IResolveFieldContext context)
        {
            base.Map(context);

            var connectionContext = (IResolveConnectionContext)context;
            LoyaltyCalculated = connectionContext.GetArgument<bool?>("loyaltyCalculated");
        }
    }
}
