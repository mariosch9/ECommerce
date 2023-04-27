using Microsoft.AspNetCore.Mvc;
using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Services;

namespace NewStarterTask.Sender.Application.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IService<Customer> _customerService;

        public CustomerController(IService<Customer> customerService)
        {
            _customerService = customerService;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            return View(await _customerService.GetAsync());
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerService.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName")] Customer customer)
        {
            var exist = await _customerService.GetByIdAsync(customer.Id) != null;
            if (!exist)
            {
                await _customerService.AddAsync(customer);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerService.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            await _customerService.UpdateAsync(customer);
            return RedirectToAction(nameof(Index));
        }

        // GET: Capabilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerService.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Capabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _customerService.DeleteAsync(customer);
            return RedirectToAction(nameof(Index));
        }
    }
}
