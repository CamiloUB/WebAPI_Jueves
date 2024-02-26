using ShoppingAPI_Jueves.DAL.Entities;

namespace ShoppingAPI_Jueves.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync();

        Task<Country> CreateCountrysAsync(Country country);

        Task<Country> GetCountryByIdAsync(Guid Id);



    }
}
