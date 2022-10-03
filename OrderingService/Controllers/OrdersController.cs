using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderingService.Commands;
using OrderingService.Models;

namespace OrderingService.Controllers
{
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _mediator.Send(new GetOrders());
            return Ok(orders);
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] ShoppingCart shoppingCart)
        {
            var result = await _mediator.Send(new CreateOrder { OrderId = Guid.NewGuid(), ShoppingCart = shoppingCart });
            return Ok(result);
        }

        [HttpPost("PlaceOrder/{orderId}")]
        public async Task<IActionResult> PlaceOrder(Guid orderId)
        {
            var result = await _mediator.Send(new PlaceOrder { OrderId = orderId });
            return Ok(result);
        }
    }
}