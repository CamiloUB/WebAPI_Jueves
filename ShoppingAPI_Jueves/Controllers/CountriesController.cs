using Microsoft.AspNetCore.Mvc;
using ShoppingAPI_Jueves.DAL.Entities;
using ShoppingAPI_Jueves.Domain.Interfaces;

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
        [Route("Getall")] // Aquí concateno la URL incial

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
                var createdCountry = await _countryService.CreateCountryAsync(country);

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
        [Route("GetById/{id}")] // Aquí concateno la URL incial
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

            return Ok(country);
        }


        [HttpGet, ActionName("Get")]
        [Route("GetByName/{name}")] // Aquí concateno la URL incial
        public async Task<ActionResult> GetCountryByNameAsync(string name)
        {
            if (name == null)
            {
                return BadRequest("Name es requerido"); //
            }

            var country = await _countryService.GetCountryByNameAsync(name);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }


        [HttpPut, ActionName("Edit")]
        [Route("Edit")] // Aquí concateno la URL incial
        public async Task<ActionResult<Country>> EditCountryAsync(Country country)

        {
            try

            {
                var editedCountry = await _countryService.EditCountryAsync(country);

                if (editedCountry == null)
                {
                    return NotFound(); // 404
                }

                return Ok(editedCountry); // 200
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

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")] // Aquí concateno la URL incial
        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)

        {
            if (id == null) return BadRequest("Id es requerido");

            var deletedCountry = await _countryService.DeleteCountryAsync(id);

            if (deletedCountry == null) return NotFound("país no encontrado"); // 200

            return Ok(deletedCountry);

        }

        // No se hace Try and Catch porque no estoy trayendo el objeto

    }
}


