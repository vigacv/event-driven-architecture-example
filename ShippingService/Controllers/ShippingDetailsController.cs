using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShippingService.Commands;
using ShippingService.Models;

namespace ShippingService.Controllers
{
    [Route("[controller]")]
    public class ShippingDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShippingDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shippingDetails = await _mediator.Send(new GetShippingDetailsList());
            return Ok(shippingDetails);
        }

        [HttpPost("StoreShippingDetailsForOrder")]
        public async Task<IActionResult> StoreShippingDetailsForOrder([FromBody] ShippingDetails shippingDetails)
        {
            await _mediator.Send(new StoreShippingDetailsForOrder { ShippingDetails = shippingDetails });
            return Ok();
        }
    }
}