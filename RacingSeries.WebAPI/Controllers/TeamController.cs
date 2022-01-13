using Microsoft.AspNetCore.Mvc;
using RacingSeries.Infrastructure.DTO;
using RacingSeries.Infrastructure.Services;
using System.Threading.Tasks;

namespace RacingSeries.WebAPI.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _TeamService;
        public TeamController(ITeamService TeamService)
        {
            _TeamService = TeamService;
        }

        // GET: TeamController
        public async Task<IActionResult> BrowseAll()
        {
            var d = await _TeamService.BrowseAll();
            return Json(d);
        }

        // GET: TeamController/5
        public async Task<IActionResult> GetTeam(int id)
        {
            var d = await _TeamService.GetTeam(id);
            return Json(d);
        }

        // POST: TeamController
        [HttpPost]
        public async Task<IActionResult> AddTeam([FromBody] TeamDTO Team)
        {
            await _TeamService.AddTeam(Team);
            return Ok();
        }

        // PUT: TeamController/5
        [HttpPut("id")]
        public async Task<IActionResult> EditTeam([FromBody] int id, TeamDTO Team)
        {
            await _TeamService.EditTeam(Team, id);
            return Ok();
        }

        // DELETE: TeamController/Delete/5
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _TeamService.DeleteTeam(id);
            return Ok();
        }
    }
}
