using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            return Ok();
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(ShoppingCart shoppingCart)
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