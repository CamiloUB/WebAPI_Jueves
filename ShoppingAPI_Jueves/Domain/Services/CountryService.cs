using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves.DAL;
using ShoppingAPI_Jueves.DAL.Entities;
using ShoppingAPI_Jueves.Domain.Interfaces;
using System.Diagnostics.Metrics;

namespace ShoppingAPI_Jueves.Domain.Services
{
    public class CountryService : ICountryService
    {

        public readonly DataBaseContext _context;

        public CountryService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {


            // Aquí se trae la lista de países
            return await _context.Countries.ToListAsync();

        }

        public async Task<Country> CreateCountrysAsync(Country country)
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
    }
    }


