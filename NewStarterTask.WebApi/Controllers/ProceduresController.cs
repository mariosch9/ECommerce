using Microsoft.AspNetCore.Mvc;
using NewStarterTask.Core.Services;

namespace NewStarterTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProceduresController : ControllerBase
    {
        private readonly IProcedureService _procedureService;

        public ProceduresController(IProcedureService procedureService)
        {
            _procedureService = procedureService;
        }

        [HttpGet]
        [Route("Reset")]
        public async Task<IActionResult> Reset()
        {
            await _procedureService.ResetDataAsync();
            return Ok();
        }

        [HttpGet]
        [Route("Seed")]
        public async Task<IActionResult> Seed()
        {
            await _procedureService.SeedDataAsync();
            return Ok();
        }
    }
}
