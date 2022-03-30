using VirtoCommerce.OrdersModule.Core.Model.Search;

namespace Training.OrdersModule.Core.Models
{
    public class TrainingOrderSearchCriteria : CustomerOrderSearchCriteria
    {
        public bool? LoyaltyCalculated { get; set; }
    }
}
