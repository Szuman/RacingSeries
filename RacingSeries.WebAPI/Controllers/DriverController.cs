using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RacingSeries.Infrastructure.DTO;
using RacingSeries.Infrastructure.Services;
using System.Threading.Tasks;

namespace RacingSeries.WebAPI.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        // GET: DriverController
        public async Task<IActionResult> BrowseAll()
        {
            var d = await _driverService.BrowseAll();
            return Json(d);
        }

        // GET: DriverController/5
        public async Task<IActionResult> GetDriver(int id)
        {
            var d = await _driverService.GetDriver(id);
            return Json(d);
        }

        // POST: DriverController
        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] DriverDTO driver)
        {
            await _driverService.AddDriver(driver);
            return Ok();
        }

        // PUT: DriverController/5
        [HttpPut("id")]
        public async Task<IActionResult> EditDriver([FromBody] int id, DriverDTO driver)
        {
            await _driverService.EditDriver(driver, id);
            return Ok();
        }

        // DELETE: DriverController/Delete/5
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            await _driverService.DeleteDriver(id);
            return Ok();
        }
    }
}
