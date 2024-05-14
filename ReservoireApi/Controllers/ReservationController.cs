using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReservoireApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {
                
        }

        [HttpGet("Get")]
        public ActionResult<string> Get(int id)
        {
            return Ok("Your Reservation");
        }
    }
}
