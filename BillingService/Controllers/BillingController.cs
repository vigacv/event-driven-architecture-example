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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orderBills = await _mediator.Send(new GetOrderBills());
            return Ok(orderBills);
        }

        [HttpPost("StorePaymentDetails")]
        public async Task<IActionResult> StorePaymentDetails([FromBody] StorePaymentDetailsForOrder command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}