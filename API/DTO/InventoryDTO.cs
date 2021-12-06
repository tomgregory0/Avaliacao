using System.Collections.Generic;
using System.Linq;

namespace API.DTO
{
    public class InventoryDTO
    {

        public long? Quantity
        {
            get
            {
                return Warehouses?.Sum(x => x.Quantity);
            }
        }

        public virtual List<WarehouseDTO> Warehouses { get; set; }
    }
}
