using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves.DAL;
using ShoppingAPI_Jueves.DAL.Entities;
using ShoppingAPI_Jueves.Domain.Interfaces;

namespace ShoppingAPI_Jueves.Domain.Services
{
    public class CountryService : ICountryService
    {

        private readonly DataBaseContext _context;

        public CountryService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            // Aquí se trae la lista de países
            return await _context.Countries.ToListAsync();

        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid(); // Así se asigna un ID a un nuevo registro
                country.CreatedDate = DateTime.Now; // Así se asigna una fecha de creación
                                                    // automatica de un nuevo registro

                _context.Countries.Add(country); // Aquí creo el objeto en el contexto BD
                await _context.SaveChangesAsync(); // Aquí inserto en BD(tabla countries)

                return country;
            }
            catch (DbUpdateException dbUpdateException)

            {
                // Crea el mensaje cuando el país está duplicado 
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {

            // return await _context.Countries.FirstAsync(x => x.Id == id); // FindAsync método del
            // DbContext (DbSet)

            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<Country> GetCountryByNameAsync(string name)
        {

            return await _context.Countries.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Country> EditCountryAsync(Country country)
        {

            try
            {
                // Con esto traigo el país desde mi BD y lo guardo en la variable

                country.ModifiedDate = DateTime.Now;

                _context.Countries.Update(country); // Aquí creo el objeto en el contexto BD
                await _context.SaveChangesAsync(); // Aquí inserto en BD(tabla countries)

                return country;
            }
            catch (DbUpdateException dbUpdateException)

            {
                // Crea el mensaje cuando el país está duplicado 
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
                if (country == null) return null;

                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();

                return country;

            }
            catch (DbUpdateException dbUpdateException)

            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }

        }




    }
}



