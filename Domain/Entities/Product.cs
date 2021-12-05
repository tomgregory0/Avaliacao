using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Product : Entity
    {
        public long SKU { get; set; }
        public string Name { get; set; }
        public bool IsMarketable
        {
            get
            {
                if (Inventory?.Quantity > 0)
                    return true;

                return false;
            }
        }

        public virtual Inventory Inventory { get; set; }
    }
}
