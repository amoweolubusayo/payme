using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using payme.Application.Commands;
using payme.Application.Models;
using payme.Application.Queries;
using payme.Core.DTOs.APIResponses;
using payme.WebAPI.Controllers;

namespace payme.Controllers
{

    [Route("api")]
    [ApiController]
    public class MerchantController : BaseController
    {
        [ProducesResponseType(typeof(CustomerResp), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CustomerResp), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("Creator")]
        public async Task<IActionResult> Creator([FromBody] CreateCustomerCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }

        [ProducesResponseType(typeof(ProductResp), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProductResp), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("Product")]
        public async Task<IActionResult> Product([FromBody] CreateProductCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }
        [ProducesResponseType(typeof(TransactionResp), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(TransactionResp), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("RecurringPayment")]
        public async Task<IActionResult> RecurringPayment([FromBody] CreatePlanCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }

        [ProducesResponseType(typeof(TransactionResp), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(TransactionResp), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpPost, Route("OneTimePayment")]
        public async Task<IActionResult> OneTimePayment([FromBody] InitializeTransactionCommand command)
        {
            var res = await Mediator.Send(command);
            return Ok(res);
        }

        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        [HttpGet, Route("Product")]
        public async Task<IActionResult> Product()
        {
            var command = new FetchAllProductsQuery();
            var res = await Mediator.Send(command);
            return Ok(res);
        }
    }
}