using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwitchConn2.Data;

namespace SwitchConn2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index(string context)
        {
            var dbContext = DbContextFactory.Create(context);
            return Ok("wellcome here");
        }
    }
}
