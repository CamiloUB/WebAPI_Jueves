using ShoppingAPI_Jueves.DAL.Entities;

namespace ShoppingAPI_Jueves.Domain.Interfaces
{
    public interface IStateService
    {

        Task<IEnumerable<State>> GetStatesByCountryIdAsync(Guid countryId);

        Task<State> CreateStateAsync(State state, Guid countryId);

        Task<State> GetStateByIdAsync(Guid id);

        Task<State> EditStateAsync(State state, Guid id);

        Task<State> DeleteStateAsync(Guid id);

    }
}
