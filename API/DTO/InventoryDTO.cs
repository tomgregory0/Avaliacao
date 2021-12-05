using System.Collections.Generic;
using System.Linq;

namespace API.DTO
{
    public class InventoryDTO
    {

        public long Quantity
        {
            get
            {
                return Warehouse.Sum(x => x.Quantity);
            }
        }

        public long ProductSKU { get; set; }
        public long ProductId { get; set; }



        public virtual List<WarehouseDTO> Warehouse { get; set; }
    }
}
