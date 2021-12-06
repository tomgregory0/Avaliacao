using Domain.Entities.Common;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Inventory : Entity
    {
        public long? Quantity
        {
            get
            {
                return Warehouses?.Sum(x => x.Quantity);
            }
        }

        public long ProductSKU { get; set; }
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        public virtual List<Warehouses> Warehouses { get; set; }
    }
}
