using Microsoft.AspNetCore.Mvc;
using ShoppingAPI_Jueves.DAL.Entities;
using ShoppingAPI_Jueves.Domain.Interfaces;
using ShoppingAPI_Jueves.Domain.Services;

namespace ShoppingAPI_Jueves.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;
        public StatesController(IStateService stateService)
        {
            _stateService = stateService;

        }

        [HttpGet, ActionName("Get")]
        [Route("Getall")] // Aquí concateno la URL incial

        public async Task<ActionResult<IEnumerable<State>>> GetStatesByCountryIdAsync(Guid countryId)

        {
         var states = await _stateService.GetStatesByCountryIdAsync(countryId);

            if (states == null || !states.Any()) return NotFound(); // 404 Http Code
            

            return Ok(states); // 200 Http Code
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")] // Aquí concateno la URL incial
        public async Task<ActionResult> CreateStateAsync(State state, Guid countryId)

        {
            try

            {
                var createdState = await _stateService.CreateStateAsync(state, countryId);

                if (createdState == null)
                {
                    return NotFound(); // 404
                }

                return Ok(createdState); // 200
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El estado {0} ya existe.", state.Name)); // 409
                }
                return Conflict(ex.Message);
            }

        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] // Aquí concateno la URL incial
        public async Task<ActionResult> GetStateByIdAsync(Guid id)
        {
            if (id == null) return BadRequest("Id es requerido"); //
            

            var state = await _stateService.GetStateByIdAsync(id);

            if (state == null) return NotFound();
           
            return Ok(state);
        }


        [HttpPut, ActionName("Edit")]
        [Route("Edit")] // Aquí concateno la URL incial
        public async Task<ActionResult<State>> EditStateAsync(State state, Guid id)

        {
            try

            {
                var editedState = await _stateService.EditStateAsync(state, id);

                if (editedState == null) return NotFound(); // 404
                
                return Ok(editedState); // 200
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El estado/provincia {0} ya existe.", state.Name)); // 409
                }
                return Conflict(ex.Message);
            }
        }


        [HttpDelete, ActionName("Delete")]
        [Route("Delete")] // Aquí concateno la URL incial
        public async Task<ActionResult<State>> DeleteStateAsync(Guid id)

        {
            if (id == null) return BadRequest("Id es requerido");

            var deletedState = await _stateService.DeleteStateAsync(id);

            if (deletedState == null) return NotFound("país no encontrado"); // 200

            return Ok(deletedState);
        }
    }

}
