using Microsoft.AspNetCore.Mvc;
using RacingSeries.Infrastructure.DTO;
using RacingSeries.Infrastructure.Services;
using System.Threading.Tasks;

namespace RacingSeries.WebAPI.Controllers
{
    public class TrackController : Controller
    {
        private readonly ITrackService _TrackService;
        public TrackController(ITrackService TrackService)
        {
            _TrackService = TrackService;
        }

        // GET: TrackController
        public async Task<IActionResult> BrowseAll()
        {
            var d = await _TrackService.BrowseAll();
            return Json(d);
        }

        // GET: TrackController/5
        public async Task<IActionResult> GetTrack(int id)
        {
            var d = await _TrackService.GetTrack(id);
            return Json(d);
        }

        // POST: TrackController
        [HttpPost]
        public async Task<IActionResult> AddTrack([FromBody] TrackDTO Track)
        {
            await _TrackService.AddTrack(Track);
            return Ok();
        }

        // PUT: TrackController/5
        [HttpPut("id")]
        public async Task<IActionResult> EditTrack([FromBody] int id, TrackDTO Track)
        {
            await _TrackService.EditTrack(Track, id);
            return Ok();
        }

        // DELETE: TrackController/Delete/5
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            await _TrackService.DeleteTrack(id);
            return Ok();
        }
    }
}
