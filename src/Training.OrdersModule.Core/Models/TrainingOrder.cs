using VirtoCommerce.OrdersModule.Core.Model;

namespace Training.OrdersModule.Core.Models
{
    public class TrainingOrder : CustomerOrder
    {
        public TrainingOrder()
        {
            OperationType = nameof(CustomerOrder);
        }

        public bool LoyaltyCalculated { get; set; }
    }
}
