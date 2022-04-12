using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EDI_Manager.Controllers
{
    [Route("api/connection")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        SFTPConnection conn =  new SFTPConnection();
        // GET: api/<ConnectionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            conn.ConnectionTest();
            return new string[] { "value1", "value2" };
        }

        // POST api/<ConnectionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }
    }
}
