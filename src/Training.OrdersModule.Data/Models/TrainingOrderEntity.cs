using Training.OrdersModule.Core.Models;
using VirtoCommerce.OrdersModule.Core.Model;
using VirtoCommerce.OrdersModule.Data.Model;
using VirtoCommerce.Platform.Core.Common;

namespace Training.OrdersModule.Data.Models
{
    public class TrainingOrderEntity : CustomerOrderEntity
    {
        public bool LoyaltyCalculated { get; set; }

        public override CustomerOrder ToModel(CustomerOrder order)
        {
            var result = base.ToModel(order);

            if (result is TrainingOrder target)
            {
                target.LoyaltyCalculated = LoyaltyCalculated;
            }

            return result;
        }

        public override CustomerOrderEntity FromModel(CustomerOrder order, PrimaryKeyResolvingMap pkMap)
        {
            var result = base.FromModel(order, pkMap);

            if (order is TrainingOrder source)
            {
                LoyaltyCalculated = source.LoyaltyCalculated;
            }

            return result;
        }

        public override void Patch(CustomerOrderEntity target)
        {
            base.Patch(target);

            if (target is TrainingOrderEntity trainingOrderEntity)
            {
                trainingOrderEntity.LoyaltyCalculated = LoyaltyCalculated;
            }
        }
    }
}
