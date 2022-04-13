using System.Threading.Tasks;
using Training.OrdersModule.Core.Models;
using VirtoCommerce.InventoryModule.Core.Services;
using VirtoCommerce.OrdersModule.Core.Model;
using VirtoCommerce.OrdersModule.Core.Services;
using VirtoCommerce.OrdersModule.Data.Search.Indexed;
using VirtoCommerce.Platform.Core.DynamicProperties;
using VirtoCommerce.SearchModule.Core.Extenstions;
using VirtoCommerce.SearchModule.Core.Model;
using VirtoCommerce.StoreModule.Core.Services;

namespace Training.OrdersModule.Data.Search.Indexed
{
    public class TrainingOrderDocumentBuilder : CustomerOrderDocumentBuilder
    {
        public TrainingOrderDocumentBuilder(
            ICustomerOrderService customerOrderService,
            IDynamicPropertySearchService dynamicPropertySearchService,
            IStoreService storeService,
            IFulfillmentCenterService fulfillmentCenterService)
            : base(customerOrderService, dynamicPropertySearchService, storeService, fulfillmentCenterService)
        {
        }


        protected override async Task<IndexDocument> CreateDocument(CustomerOrder order)
        {
            var document = await base.CreateDocument(order);

            if (order is TrainingOrder trainingOrder)
            {
                document.AddFilterableValue("LoyaltyCalculated", trainingOrder.LoyaltyCalculated, IndexDocumentFieldValueType.Boolean);
            }

            return document;
        }
    }
}
