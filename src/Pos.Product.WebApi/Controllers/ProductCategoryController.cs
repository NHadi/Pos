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
using Pos.Product.WebApi.Application.Commands.ProductCategories;
using Pos.Product.WebApi.Application.Queries;

namespace Pos.Product.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommandHandler<CreateProductCategoryCommand> _createProductCategoryCommand;
        private readonly ICommandHandler<UpdateProductCategoryCommand> _updateProductCategoryCommand;
        private readonly ICommandHandler<DeleteProductCategoryCommand> _deleteProductCategoryCommand;
        private readonly IProductCategoryQueries _productCategoryQueries;
        private readonly ILogger<ProductCategoryController> _logger;

        public ProductCategoryController(IMapper mapper,
            ICommandHandler<CreateProductCategoryCommand> createProductCategoryCommand,
            ICommandHandler<UpdateProductCategoryCommand> updateProductCategoryCommand,
            ICommandHandler<DeleteProductCategoryCommand> deleteProductCategoryCommand,
            IProductCategoryQueries productCategoryQueries,
            ILogger<ProductCategoryController> logger)
        {
            _mapper = mapper;
            _createProductCategoryCommand = createProductCategoryCommand;
            _updateProductCategoryCommand = updateProductCategoryCommand;
            _deleteProductCategoryCommand = deleteProductCategoryCommand;
            _productCategoryQueries = productCategoryQueries;
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _productCategoryQueries.GetDatas();

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
                var data = await _productCategoryQueries.GetData(id);

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
        public async Task<IActionResult> Post([FromBody] CreateProductCategoryCommand request)
        {
            try
            {
                await _createProductCategoryCommand.Handle(request, CancellationToken.None);
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Insert Product Cattegory");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        // PUT api/customer
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCategoryCommand request)
        {
            try
            {
                await _updateProductCategoryCommand.Handle(request, CancellationToken.None);
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Insert ProductCategory");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        // DELETE api/customer/idCustomer
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleteProductCategoryCommand = new DeleteProductCategoryCommand {  PoductCategoryId = id };
                await _deleteProductCategoryCommand.Handle(deleteProductCategoryCommand, CancellationToken.None);
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
