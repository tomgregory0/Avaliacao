using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Warehouses : Entity
    {
        public long InventoryId { get; set; }
        public string Locality { get; set; }
        public long Quantity { get; set; }
        public string Type { get; set; }

        public virtual Inventory Inventory { get; set; }

    }
}
