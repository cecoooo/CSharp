using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierImportDTO, Supplier>();
            CreateMap<PartImportDTO, Part>();
            CreateMap<CarImportDTO, Car>();
            CreateMap<CustomerImportDTO, Customer>();
            CreateMap<SaleImportDTO, Sale>();
        }
    }
}
