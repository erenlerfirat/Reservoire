using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReservoireApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        public ReservationController()
        {
                
        }

        [HttpGet("Get")]
        public ActionResult<string> Get(int id)
        {
            return Ok("Your Reservation");
        }

        [HttpGet("Book")]
        public ActionResult<string> Book(int id)
        {
            return Ok("Your Reservation");
        }

        [HttpGet("Edit")]
        public ActionResult<string> Edit(int id)
        {
            return Ok("Your Reservation");
        }
        [HttpGet("Cancel")]
        public ActionResult<string> Cancel(int id)
        {
            return Ok("Your Reservation");
        }
    }
}
