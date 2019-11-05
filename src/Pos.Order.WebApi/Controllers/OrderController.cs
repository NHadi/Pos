using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dermayon.Common.Api;
using Dermayon.Common.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pos.Customer.WebApi.Application.Queries;
using Pos.Order.WebApi.Application.Commands;

namespace Pos.Order.WebApi.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommandHandler<CreateOrderCommand> _createOrderCommand;        
        private readonly IOrderQueries _orderQueries;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IMapper mapper, 
            ICommandHandler<CreateOrderCommand> createOrderCommand,
            IOrderQueries orderQueries,
            ILogger<OrderController> logger
            )
        {
            _mapper = mapper;
            _createOrderCommand = createOrderCommand;
            _orderQueries = orderQueries;
            _logger = logger;
        }

        // GET api/order
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _orderQueries.GetOrders();

                return Ok(new ApiOkResponse(data, data.Count()));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error on Get Orders");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        // GET api/order/id
        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var data = await _orderQueries.GetOrder(id);

                return Ok(new ApiOkResponse(data, data != null ? 1 : 0));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error on Get Order");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        // POST api/customer
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommand request)
        {
            try
            {
                await _createOrderCommand.Handle(request, CancellationToken.None);
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Insert Order");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }
    }
}
