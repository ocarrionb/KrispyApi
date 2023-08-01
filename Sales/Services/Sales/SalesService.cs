using AutoMapper;
using Sales.Entities.Dtos.Sales;
using Sales.Entities.Sales;
using Sales.Repository.Sales;

namespace Sales.Services.Sales
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;

        public SalesService(ISalesRepository salesRepository, IMapper mapper) 
        {
            _salesRepository = salesRepository;
            _mapper = mapper;
        }

        public ICollection<SaleDto> GetAllSales()
        {
            var listSales = _salesRepository.GetAllSales();
            var listSalesDto = new List<SaleDto>();

            foreach (var item in listSales) {
                listSalesDto.Add(_mapper.Map<SaleDto>(item));
            }
            return listSalesDto;
        }

        public bool PostSale(CreateSaleDto saleDto)
        {
            var sale = _mapper.Map<Sale>(saleDto);

            return _salesRepository.PostSale(sale);
        }

        public SaleDto GetSale(int id)
        {
            var sale = _salesRepository.GetSale(id);
            return _mapper.Map<SaleDto>(sale);
        }
    }
}
