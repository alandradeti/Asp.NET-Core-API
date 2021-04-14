using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.WebAPI.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IProAgilRepository _repository;

        public EventController(IProAgilRepository repository)
        {
            _repository = repository;
        }

        //GET Default route without parameter
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetAllEventsAsync(true);
                
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

        //GET Route with parameter pass "eventId"
        [HttpGet("{eventId}")]
        public async Task<IActionResult> Get(int eventId)
        {
            try
            {
                var results = await _repository.GetEventAsyncById(eventId, true);
                
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

        //GET Route with parameter pass "theme"
        [HttpGet("getByTheme/{theme}")]
        public async Task<IActionResult> Get(string theme)
        {
            try
            {
                var results = await _repository.GetAllEventsAsyncByTheme(theme, true);
                
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

        //POST Default route without parameter
        [HttpPost]
        public async Task<IActionResult> Post(Event model)
        {
            try
            {
                _repository.Add(model);

                if(await _repository.SaveChangeAsync())
                {
                    return Created($"/api/event/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }

            return BadRequest();
        }
    
        [HttpPut("{eventId}")]
        public async Task<IActionResult> Put(int eventId, Event model)
        {
            try
            {
                var foundEvent = await _repository.GetEventAsyncById(eventId, false);
                if(foundEvent == null) return NotFound();

                _repository.Update(model);

                if(await _repository.SaveChangeAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }

            return BadRequest();
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> Delete(int eventId)
        {
            try
            {
                var foundEvent = await _repository.GetEventAsyncById(eventId, false);
                if(foundEvent == null) return NotFound();

                _repository.Delete(foundEvent);

                if(await _repository.SaveChangeAsync())
                {
                    return Ok();
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }

            return BadRequest();
        }

    }
}