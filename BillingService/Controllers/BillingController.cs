using BillingService.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BillingService.Controllers
{
    [Route("[controller]")]
    public class BillingController: ControllerBase
    {
        private readonly IMediator _mediator;

        public BillingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("StorePaymentDetails")]
        public async Task<IActionResult> StorePaymentDetails(StorePaymentDetailsForOrder command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}