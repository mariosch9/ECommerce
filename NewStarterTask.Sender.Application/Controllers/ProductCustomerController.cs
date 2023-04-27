using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Services;

namespace NewStarterTask.Sender.Application.Controllers
{
    public class ProductCustomerController : Controller
    {
        private readonly IService<ProductCustomer> _productCustomerService;
        private readonly IService<Product> _productService;
        private readonly IService<Customer> _customerService;

        public ProductCustomerController(IService<ProductCustomer> productCustomerService, IService<Product> productService, IService<Customer> customerService)
        {
            _productCustomerService = productCustomerService;
            _productService = productService;
            _customerService = customerService;

        }

        // GET: ProductCustomer
        public async Task<IActionResult> Index()
        {
            return View(await _productCustomerService.GetAsync());
        }

        // GET: ProductCustomer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _productCustomerService.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: ProductCustomer/Create
        public async Task<IActionResult> Create()
        {
            var products = await _productService.GetAsync();
            var customers = await _customerService.GetAsync();
            ViewData["ProductId"] = new SelectList(products, "Id", "Name");
            ViewData["CustomerId"] = new SelectList(customers, "Id", "FirstName");
            return View();
        }

        // POST: ProductCustomer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCustomer productCustomer)
        {
            var exist = await _productCustomerService.GetByIdAsync(productCustomer.Id) != null;
            if (!exist)
            {
                await _productCustomerService.AddAsync(productCustomer);
            }
            
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductCustomer/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            var products = await _productService.GetAsync();
            var customers = await _customerService.GetAsync();
            ViewData["ProductId"] = new SelectList(products, "Id", "Name");
            ViewData["CustomerId"] = new SelectList(customers, "Id", "FirstName");

            return View(productCustomer);
        }

        // POST: ProductCustomer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "CustomerId, ProductId")] ProductCustomer productCustomer)
        {
            if (id != productCustomer.Id)
            {
                return NotFound();
            }

            await _productCustomerService.UpdateAsync(productCustomer);
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductCustomer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _productCustomerService.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: ProductCustomer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _productCustomerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _productCustomerService.DeleteAsync(customer);
            return RedirectToAction(nameof(Index));
        }
    }
}
