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
using Pos.Product.WebApi.Application.Commands;

namespace Pos.Product.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommandHandler<CreateProductCommand> _createProductCommand;
        private readonly ICommandHandler<UpdateProductCommand> _updateProductCommand;
        private readonly ICommandHandler<DeleteProductCommand> _deleteProductCommand;
        private readonly IProductQueries _productQueries;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IMapper mapper,
            ICommandHandler<CreateProductCommand> createProductCommand,
            ICommandHandler<UpdateProductCommand> updateProductCommand,
            ICommandHandler<DeleteProductCommand> deleteProductCommand,
            IProductQueries productCategoryQueries,
            ILogger<ProductController> logger)
        {
            _mapper = mapper;
            _createProductCommand = createProductCommand;
            _updateProductCommand = updateProductCommand;
            _deleteProductCommand = deleteProductCommand;
            _productQueries = productCategoryQueries;
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _productQueries.GetProducts();

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
                var data = await _productQueries.GetProduct(id);

                return Ok(new ApiOkResponse(data, data != null ? 1 : 0));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Get Customer [{id}]");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        // POST api/product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand request)
        {
            try
            {
                await _createProductCommand.Handle(request, CancellationToken.None);
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Insert Product Cattegory");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        // PUT api/product
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommand request)
        {
            try
            {
                await _updateProductCommand.Handle(request, CancellationToken.None);
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Insert Product");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        // DELETE api/product/idCustomer
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleteProductCommand = new DeleteProductCommand { ProductId = id };
                await _deleteProductCommand.Handle(deleteProductCommand, CancellationToken.None);
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Delete Product Category [{id}]");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }
    }
}
