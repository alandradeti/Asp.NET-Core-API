using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.WebAPI.Model;
using ProAgil.WebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {

        public readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }

        //GET Default route without parameter
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Events.ToListAsync();
                
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

        //GET Route with parameter pass "Id" to be informed in the url
        [HttpGet ("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var results = await _context.Events.FirstOrDefaultAsync(x => x.EventId == id);;
                
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }
    }
}
