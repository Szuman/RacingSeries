using Microsoft.AspNetCore.Mvc;
using RacingSeries.Infrastructure.DTO;
using RacingSeries.Infrastructure.Services;
using System.Threading.Tasks;

namespace RacingSeries.WebAPI.Controllers
{
    public class ContestController : Controller
    {
        private readonly IContestService _ContestService;
        public ContestController(IContestService ContestService)
        {
            _ContestService = ContestService;
        }

        // GET: ContestController
        public async Task<IActionResult> BrowseAll()
        {
            var d = await _ContestService.BrowseAll();
            return Json(d);
        }

        // GET: ContestController/5
        public async Task<IActionResult> GetContest(int id)
        {
            var d = await _ContestService.GetContest(id);
            return Json(d);
        }

        // POST: ContestController
        [HttpPost]
        public async Task<IActionResult> AddContest([FromBody] ContestDTO Contest)
        {
            await _ContestService.AddContest(Contest);
            return Ok();
        }

        // PUT: ContestController/5
        [HttpPut("id")]
        public async Task<IActionResult> EditContest([FromBody] int id, ContestDTO Contest)
        {
            await _ContestService.EditContest(Contest, id);
            return Ok();
        }

        // DELETE: ContestController/5
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteContest(int id)
        {
            await _ContestService.DeleteContest(id);
            return Ok();
        }
    }
}
