using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RacingSeries.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RacingSeries.WebApp.Controllers
{
    public class SponsorController : Controller
    {
        public IConfiguration Configuration;
        private readonly HttpClientHandler clientHandler = new HttpClientHandler();

        public SponsorController(IConfiguration configuration)
        {
            Configuration = configuration;
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public ContentResult GetHostUrl()
        {
            var result = Configuration["RestApiUrl:HostUrl"];
            return Content(result);
        }

        private string CN()
        {
            string cn = ControllerContext.RouteData.Values["controller"].ToString();
            return cn;
        }

        // GET: SponsorController
        public async Task<IActionResult> Index()
        {
            string _restpath = GetHostUrl().Content + CN();
            List<SponsorVM> Sponsors = new List<SponsorVM>();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Sponsors = JsonConvert.DeserializeObject<List<SponsorVM>>(apiResponse);
                }
            }
            return View(Sponsors);
        }

        // GET: SponsorController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: SponsorController/Create
        public IActionResult Create()
        {
            SponsorVM SponsorVM = new SponsorVM();
            return View(SponsorVM);
        }

        // POST: SponsorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SponsorVM SponsorVM)
        {
            string _restpath = GetHostUrl().Content + CN();
            SponsorVM result = new SponsorVM();
            try
            {
                using (var httpClient = new HttpClient(clientHandler))
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(SponsorVM);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(_restpath, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<SponsorVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: SponsorController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            SponsorVM SponsorVM = new SponsorVM();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    SponsorVM = JsonConvert.DeserializeObject<SponsorVM>(apiResponse);
                }
            }
            return View(SponsorVM);
        }

        // POST: SponsorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SponsorVM SponsorVM)
        {
            string _restpath = GetHostUrl().Content + CN();
            SponsorVM result = new SponsorVM();
            try
            {
                using (var httpClient = new HttpClient(clientHandler))
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(SponsorVM);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{SponsorVM.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<SponsorVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: SponsorController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            SponsorVM SponsorVM = new SponsorVM();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.DeleteAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    SponsorVM = JsonConvert.DeserializeObject<SponsorVM>(apiResponse);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
