using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TDDMicroExercises.Features.TicketDispenser
{
    [ApiController]
    [Route("[controller]")]
    public class TicketDispenserController : ControllerBase
    {
        private readonly ILogger<TicketDispenserController> logger;
        private readonly TicketDispenser ticketDispenser;

        public TicketDispenserController(ILogger<TicketDispenserController> logger)
        {
            this.logger = logger;
            this.ticketDispenser = new TicketDispenser();
        }

        [Route("")]
        [HttpGet]
        public TurnTicket GetTurnTicket() => ticketDispenser.GetTurnTicket();
    }
}
