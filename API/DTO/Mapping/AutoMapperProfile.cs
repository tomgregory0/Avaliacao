using AutoMapper;
using Domain.Entities;

namespace API.DTO.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Inventory, InventoryDTO>().ReverseMap();
            CreateMap<Warehouse, WarehouseDTO>().ReverseMap();
        }
    }
}
