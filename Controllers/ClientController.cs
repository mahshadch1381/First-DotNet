using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testing_easy_db.Data;
using testing_easy_db.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testing_easy_db.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly dataContext _Context;
        public ClientController(dataContext context)
        {
            _Context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Client>>> Get()
        {
            return Ok(await _Context.Clients.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            var b = await _Context.Clients.FindAsync(id);
            if (b == null)
            {
                return NotFound();
            }
            return Ok(b);
        }
        [HttpPost]
        public async Task<ActionResult<List<Client>>> Post(Client c)
        {
            _Context.InsertWithIdentityOn_client(c);
            await _Context.SaveChangesAsync();
            return Ok(await _Context.Clients.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Client>>> Update(Client Req)
        {
            var dbb = await _Context.Clients.FindAsync(Req.Id);
            if (dbb == null)
                return NotFound();
            dbb.Name = Req.Name;
            dbb.Name = Req.Name;
            dbb.LastName = Req.LastName;


            await _Context.SaveChangesAsync();

            return Ok(await _Context.Clients.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Client>>> Delete(int id)
        {
            var dbb = await _Context.Clients.FindAsync(id);
            if (dbb == null)
                return NotFound();
            _Context.Clients.Remove(dbb);
            await _Context.SaveChangesAsync();
            return Ok(await _Context.Clients.ToListAsync());
        }
    
}
}
