using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves.DAL;
using ShoppingAPI_Jueves.DAL.Entities;
using ShoppingAPI_Jueves.Domain.Interfaces;
using System.Diagnostics.Metrics;

namespace ShoppingAPI_Jueves.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DataBaseContext _context;

        public StateService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> GetStatesByCountryIdAsync(Guid countryId)
        {
            return await _context.States
                .Where(s => s.CountryId == countryId)
                .ToListAsync();
        }
        public async Task<State> CreateStateAsync(State state, Guid countryId)
        {
            try
            {
                state.Id = Guid.NewGuid(); // Así se asigna un ID a un nuevo registro
                state.CreatedDate = DateTime.Now; // Así se asigna una fecha de creación
                state.CountryId = countryId;
                state.Country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == countryId);    // automatica de un nuevo registro
                state.ModifiedDate = null;


                _context.States.Add(state); // Aquí creo el objeto en el contexto BD
                await _context.SaveChangesAsync(); // Aquí inserto en BD(tabla countries)

                return state;
            }
            catch (DbUpdateException dbUpdateException)

            {
                // Crea el mensaje cuando el país está duplicado 
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }

        }

        public async Task<State> GetStateByIdAsync(Guid id)
        {
            return await _context.States.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<State> EditStateAsync(State state, Guid id)
        {
            try
            {
                // Con esto traigo el país desde mi BD y lo guardo en la variable

                state.ModifiedDate = DateTime.Now;

                _context.States.Update(state); // Aquí creo el objeto en el contexto BD
                await _context.SaveChangesAsync(); // Aquí inserto en BD(tabla countries)

                return state;
            }
            catch (DbUpdateException dbUpdateException)

            {
                // Crea el mensaje cuando el país está duplicado 
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

        public async Task<State> DeleteStateAsync(Guid id)
        {
            try
            {
                var state = await _context.States.FirstOrDefaultAsync(s => s.Id == id);
                if (state == null) return null;

                _context.States.Remove(state);
                await _context.SaveChangesAsync();

                return state;

            }
            catch (DbUpdateException dbUpdateException)

            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

      
    }
}
