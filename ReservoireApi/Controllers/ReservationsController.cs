using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReservoireApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService reservationService;
        public ReservationsController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok("Your Reservation");
        }

        [HttpPost]
        [Route("{id}")]
        public ActionResult<string> Book(int id)
        {
            return Ok("Your Reservation");
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<string> Edit(int id)
        {
            return Ok("Your Reservation");
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<string> Cancel(int id)
        {
            return Ok("Your Reservation");
        }
    }
}
