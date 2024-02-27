using ShoppingAPI_Jueves.DAL.Entities;

namespace ShoppingAPI_Jueves.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync();

        Task<Country> CreateCountryAsync(Country country);

        Task<Country> GetCountryByIdAsync(Guid Id);

        Task<Country> GetCountryByNameAsync(string name);

        Task<Country> EditCountryAsync(Country country);

        Task<Country> DeleteCountryAsync(Guid id);





    }
}
