using ShoppingAPI_Jueves.DAL.Entities;

namespace ShoppingAPI_Jueves.Domain.Interfaces
{
    public interface IStateService
    {

        Task<State> CreateCountrysAsync(Country country);

    }
}
