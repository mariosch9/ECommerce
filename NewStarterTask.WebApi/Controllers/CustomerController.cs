using Microsoft.AspNetCore.Mvc;
using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Models;
using NewStarterTask.Core.Services;

namespace NewStarterTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IService<Customer> _capabilityService;

        public CustomerController(IService<Customer> capabilityService)
        {
            _capabilityService = capabilityService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _capabilityService.GetAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _capabilityService.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Customer customer)
        {
            var exist = await _capabilityService.GetByIdAsync(customer.Id) != null;
            if (!exist)
            {
                await _capabilityService.AddAsync(customer);
                return Ok();
            }

            return BadRequest(new ErrorModel
            {
                Error = $"Capability with id {customer.Id} already exist"
            });
        }

        [HttpPut]
        public async Task<IActionResult> Edit([Bind("Id,Name,Description")] Customer customer)
        {
            var exist = await _capabilityService.GetByIdAsync(customer.Id) != null;
            if (!exist)
            {
                return NotFound();
            }

            await _capabilityService.UpdateAsync(customer);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _capabilityService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _capabilityService.DeleteAsync(customer);
            return Ok();
        }
    }
}
