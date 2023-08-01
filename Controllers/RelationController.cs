using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using testing_easy_db.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testing_easy_db.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationController : ControllerBase
    {
        // GET: api/<RelationController>
        private readonly IRelationForOtherApi _relationForOtherApi;
        public RelationController(IRelationForOtherApi relationForOtherApi)
        {

            _relationForOtherApi = relationForOtherApi;
          
           
        }
        [HttpGet]
        public async Task<IActionResult> Get(string relativeUri)
        {
            try
            {

                string apiResponse = await _relationForOtherApi.GetSomeDataFromApi(relativeUri);
                return Ok(apiResponse); ;
            }
            catch (HttpRequestException ex)
            {
               
                Console.WriteLine($"HttpRequestException: {ex.Message}");
                return BadRequest("Error occurred during the request.");
            }
        }

        // GET api/<RelationController>/5
        //ttpGet("{id}")]
        //blic string Get(int id)
        //
        //turn "value";
        //

        // POST api/<RelationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RelationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RelationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
