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
        }
    }
}
