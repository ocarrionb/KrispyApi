using AutoMapper;
using Sales.Entities.Dtos.Sales;
using Sales.Entities.Sales;

namespace Sales.Mapper.Sales
{
    public class SaleMapper : Profile
    {
        public SaleMapper() { 
        CreateMap<Sale, SaleDto>().ReverseMap();
        CreateMap<Sale, CreateSaleDto>().ReverseMap();
        }
    }
}
