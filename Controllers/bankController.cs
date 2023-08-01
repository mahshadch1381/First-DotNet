using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testing_easy_db.Data;
using testing_easy_db.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testing_easy_db.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bankController : ControllerBase
    {
        private readonly dataContext _Context;
        public bankController(dataContext context)
        {
            _Context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<bank>>> Get()
        {
            return Ok(await _Context.banks.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<bank>> Get(int id)
        {
            var b = await _Context.banks.FindAsync(id);
            if (b == null)
            {
                return NotFound();
            }
            return Ok(b);
        }
        [HttpPost]
        public async Task<ActionResult<List<bank>>> Post(bank b)
        {
            _Context.InsertWithIdentityOn(b);
            await _Context.SaveChangesAsync();
            return Ok(await _Context.banks.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<bank>>> Update(bank Req)
        {
            var dbb = await _Context.banks.FindAsync(Req.Id);
            if (dbb == null)
                return NotFound();
            dbb.Name = Req.Name;
            dbb.Name = Req.Name;
            dbb.LastName = Req.LastName;
            

            await _Context.SaveChangesAsync();

            return Ok(await _Context.banks.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<bank>>> Delete(int id)
        {
            var dbb = await _Context.banks.FindAsync(id);
            if (dbb == null)
                return NotFound();
            _Context.banks.Remove(dbb);
            await _Context.SaveChangesAsync();
            return Ok(await _Context.banks.ToListAsync());
        }
    }
}
