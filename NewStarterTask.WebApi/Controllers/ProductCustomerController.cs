using Microsoft.AspNetCore.Mvc;
using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Models;
using NewStarterTask.Core.Services;

namespace NewStarterTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCustomerController : Controller
    {
        private readonly IService<ProductCustomer> _productCustomerService;

        public ProductCustomerController(IService<ProductCustomer> productCustomerService)
        {
            _productCustomerService = productCustomerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _productCustomerService.GetAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCustomer = await _productCustomerService.GetByIdAsync(id.Value);
            if (productCustomer == null)
            {
                return NotFound();
            }

            return Ok(productCustomer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCustomer productCustomer)
        {
            var exist = await _productCustomerService.GetByIdAsync(productCustomer.Id) != null;
            if (!exist)
            {
                await _productCustomerService.AddAsync(productCustomer);
                return Ok();
            }

            return BadRequest(new ErrorModel
            {
                Error = $"Order with id {productCustomer.Id} already exists"
            });
        }

        [HttpPut]
        public async Task<IActionResult> Edit([Bind("Id", "CustomerId, ProductId")] ProductCustomer productCustomer)
        {
            await _productCustomerService.UpdateAsync(productCustomer);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _productCustomerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _productCustomerService.DeleteAsync(customer);
            return Ok();
        }
    }
}
