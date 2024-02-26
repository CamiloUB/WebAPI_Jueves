using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using ShoppingAPI_Jueves.DAL.Entities;
using ShoppingAPI_Jueves.Domain.Interfaces;
using System.Collections.Generic;

namespace ShoppingAPI_Jueves.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // Esta es la primera parte de la URL de esta API
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // En Controller los métodos son acciones, y en API se denominan End Points
        // Todo EP retorna un Action Results.

         [HttpGet, ActionName("Get")]
         [Route("Get")] // Aquí concateno la URL incial
       
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()

        {
            // Yendo a capa Domain para traer la lista de países
            var countries = await _countryService.GetCountriesAsync();

            if (countries == null || !countries.Any()) 
            {
                return NotFound(); // 404 Http Code
            }

            return Ok(countries); // 200 Http Code
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")] // Aquí concateno la URL incial
        public async Task<ActionResult> CreateCountryAsync(Country country)

        {
            try

            {
                var createdCountry = await _countryService.CreateCountrysAsync(country);

                if (createdCountry == null) 
                {
                    return NotFound(); // 404
                }

                return Ok(createdCountry); // 200
            }
        
            catch (Exception ex) 
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El país {0} ya existe.", country.Name)); // 409
                }
                return Conflict(ex.Message);
            }
            
            }
        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")] // Aquí concateno la URL incial
        public async Task<ActionResult> GetCountryByIdAsync(Guid id)
        {
            if (id == null)
            {
                return BadRequest("Id es requerido"); //
            }

            var country = await _countryService.GetCountryByIdAsync(id);
            
            if (country == null)
            {
              return NotFound();
             }

            return Ok(country); // 200



        }

        }
    }


