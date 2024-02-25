using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves.DAL;
using ShoppingAPI_Jueves.DAL.Entities;
using ShoppingAPI_Jueves.Domain.Interfaces;

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
    }
}
