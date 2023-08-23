using AutoMapper;
using VehicleManager.Models;
using VehicleManager.ViewModels;

namespace VehicleManager
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<VehicleCategory, Index2VM>();
            CreateMap<Car, Index2VM>();
            CreateMap<Rental, Index2VM>();

            CreateMap<VehicleCategory, IndexVM>();

            CreateMap<VehicleCategory, RentalCustomerVM>();
            CreateMap<Car, RentalCustomerVM>();
            CreateMap<Rental, RentalCustomerVM>();
            CreateMap<Customer, RentalCustomerVM>();

            CreateMap<Car, RentalViewModel>();
            CreateMap<Rental, RentalViewModel>();
            CreateMap<Customer, RentalViewModel>();

        }

    }
}
