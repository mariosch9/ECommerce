using Microsoft.AspNetCore.Mvc;
using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Models;
using NewStarterTask.Core.Services;

namespace NewStarterTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IService<Product> _productService;

        public ProductController(IService<Product> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _productService.GetAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Product product)
        {
            var exist = await _productService.GetByIdAsync(product.Id) != null;
            if (!exist)
            {
                await _productService.AddAsync(product);
                return Ok();
            }

            return BadRequest(new ErrorModel
            {
                Error = $"Product with id {product.Id} already exists"
            });
        }
        
        [HttpPut]
        public async Task<IActionResult> Edit([Bind("Id,Name,Price")] Product product)
        {
            await _productService.UpdateAsync(product);
            return Ok();
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(product);
            return Ok();
        }
    }
}
