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
using Pos.Customer.WebApi.Application.Commands;
using Pos.Customer.WebApi.Application.Queries;

namespace Pos.Customer.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommandHandler<CreateCustomerCommand> _createCustomerCommand;
        private readonly ICommandHandler<UpdateCustomerCommand> _updateCustomerCommand;
        private readonly ICommandHandler<DeleteCustomerCommand> _deleteCustomerCommand;
        private readonly ICustomerQueries _customerQueries;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IMapper mapper, 
            ICommandHandler<CreateCustomerCommand> createCustomerCommand,
            ICommandHandler<UpdateCustomerCommand> updateCustomerCommand,
            ICommandHandler<DeleteCustomerCommand> deleteCustomerCommand,
            ICustomerQueries customerQueries,
            ILogger<CustomerController> logger)
        {
            _mapper = mapper;
            _createCustomerCommand = createCustomerCommand;
            _updateCustomerCommand = updateCustomerCommand;
            _deleteCustomerCommand = deleteCustomerCommand;
            _customerQueries = customerQueries;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _customerQueries.GetCustomers();

                return Ok(new ApiOkResponse(data, data.Count()));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error on Get Customers");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var data = await _customerQueries.GetCustomer(id);

                return Ok(new ApiOkResponse(data, data != null ? 1 : 0));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Get Customer [{id}]");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        // POST api/customer
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerCommand request)
        {
            try
            {                
                await _createCustomerCommand.Handle(request, CancellationToken.None);                
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Insert Customer [Name, Phone, Address ({request.Name},{request.Phone},{request.Address})]");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        // PUT api/customer
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCustomerCommand request)
        {
            try
            {
                await _updateCustomerCommand.Handle(request, CancellationToken.None);
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Insert Customer [Name, Phone, Address ({request.Name},{request.Phone},{request.Address})]");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        // DELETE api/customer/idCustomer
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleteCustomerCommand = new DeleteCustomerCommand { CustomerId = id };
                await _deleteCustomerCommand.Handle(deleteCustomerCommand, CancellationToken.None);
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Delete Customer [{id}]");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }
    }
}
