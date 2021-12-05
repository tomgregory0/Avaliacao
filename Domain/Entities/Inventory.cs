using Domain.Entities.Common;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Inventory : Entity
    {
        //public Inventory() 
        //{
        //    Warehouse = new List<Warehouse>();
        //}
        public long Quantity
        {
            get
            {
                return Warehouse.Sum(x => x.Quantity);
            }
        }

        public long ProductSKU { get; set; }
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        public virtual List<Warehouse> Warehouse { get; set; }
    }
}
