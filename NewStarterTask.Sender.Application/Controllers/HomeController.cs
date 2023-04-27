using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewStarterTask.Core.Models;
using NewStarterTask.Core.Services;

namespace NewStarterTask.Sender.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProcedureService _procedureService;

        public HomeController(ILogger<HomeController> logger, IProcedureService procedureService)
        {
            _logger = logger;
            _procedureService = procedureService;
        }

        [HttpGet]
        public async Task<IActionResult> Reset()
        {
            await _procedureService.ResetDataAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Seed()
        {
            await _procedureService.SeedDataAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}