using Mapster;
using RentalService.BL.DTO;
using RentalService.DAL.Entities;

namespace RentalService.DAL.Configurations
{
    public static class MapsterConfiguration
    {
        public static void SetupTypeAdapter()
        {
            TypeAdapterConfig<City, CityDTO>
                .NewConfig()
                .Map(dest => dest.CountryName, src => src.Country.Name);

            TypeAdapterConfig<Car, CarDTO>
                .NewConfig()
                .Map(dest => dest.BrandName, src => src.Brand.Name);

            TypeAdapterConfig<RentalPoint, BaseRentalPointDTO>
                .NewConfig()
                .Map(dest => dest.CompanyName, src => src.Company.Name ?? string.Empty);

            TypeAdapterConfig<RentalPointCar, RentalPointCarDTO>
                .NewConfig()
                .Map(dest => dest.CarName, src => src.Car.Name);
        }
    }
}
