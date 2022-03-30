using GraphQL.Server;
using Microsoft.Extensions.DependencyInjection;
using Training.OrdersModule.Xapi.Schemas;
using VirtoCommerce.ExperienceApiModule.Core.Extensions;
using VirtoCommerce.ExperienceApiModule.XOrder.Schemas;

namespace Training.OrdersModule.Xapi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddXTrainingOrder(this IServiceCollection serviceCollection, IGraphQLBuilder graphQlBuilder)
        {
            graphQlBuilder.AddGraphTypes(typeof(XTrainingOrderAnchor));

            serviceCollection.AddSchemaType<TrainingOrderType>().OverrideType<CustomerOrderType, TrainingOrderType>();

            // TODO: replace the SearchOrderQuery with TrainingSearchOrderQuery when it will be done

            return serviceCollection;
        }
    }
}
