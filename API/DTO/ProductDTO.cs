namespace API.DTO
{
    public class ProductDTO
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

        public virtual InventoryDTO Inventory { get; set; }
    }
}


