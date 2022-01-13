﻿using Microsoft.AspNetCore.Mvc;
using RacingSeries.Infrastructure.DTO;
using RacingSeries.Infrastructure.Services;
using System.Threading.Tasks;

namespace RacingSeries.WebAPI.Controllers
{
    public class SponsorController : Controller
    {
        private readonly ISponsorService _SponsorService;
        public SponsorController(ISponsorService SponsorService)
        {
            _SponsorService = SponsorService;
        }

        // GET: SponsorController
        public async Task<IActionResult> BrowseAll()
        {
            var d = await _SponsorService.BrowseAll();
            return Json(d);
        }

        // GET: SponsorController/5
        public async Task<IActionResult> GetSponsor(int id)
        {
            var d = await _SponsorService.GetSponsor(id);
            return Json(d);
        }

        // POST: SponsorController
        [HttpPost]
        public async Task<IActionResult> AddSponsor([FromBody] SponsorDTO Sponsor)
        {
            await _SponsorService.AddSponsor(Sponsor);
            return Ok();
        }

        // PUT: SponsorController/5
        [HttpPut("id")]
        public async Task<IActionResult> EditSponsor([FromBody] int id, SponsorDTO Sponsor)
        {
            await _SponsorService.EditSponsor(Sponsor, id);
            return Ok();
        }

        // DELETE: SponsorController/Delete/5
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteSponsor(int id)
        {
            await _SponsorService.DeleteSponsor(id);
            return Ok();
        }
    }
}
