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
    public class TrackController : Controller
    {
        public IConfiguration Configuration;
        private readonly HttpClientHandler clientHandler = new HttpClientHandler();

        public TrackController(IConfiguration configuration)
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

        // GET: TrackController
        public async Task<IActionResult> Index()
        {
            string _restpath = GetHostUrl().Content + CN();
            List<TrackVM> Tracks = new List<TrackVM>();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Tracks = JsonConvert.DeserializeObject<List<TrackVM>>(apiResponse);
                }
            }
            return View(Tracks);
        }

        // GET: TrackController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: TrackController/Create
        public IActionResult Create()
        {
            TrackVM TrackVM = new TrackVM();
            return View(TrackVM);
        }

        // POST: TrackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrackVM TrackVM)
        {
            string _restpath = GetHostUrl().Content + CN();
            TrackVM result = new TrackVM();
            try
            {
                using (var httpClient = new HttpClient(clientHandler))
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(TrackVM);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(_restpath, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<TrackVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TrackController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            TrackVM TrackVM = new TrackVM();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    TrackVM = JsonConvert.DeserializeObject<TrackVM>(apiResponse);
                }
            }
            return View(TrackVM);
        }

        // POST: TrackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TrackVM TrackVM)
        {
            string _restpath = GetHostUrl().Content + CN();
            TrackVM result = new TrackVM();
            try
            {
                using (var httpClient = new HttpClient(clientHandler))
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(TrackVM);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{TrackVM.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<TrackVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TrackController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            TrackVM TrackVM = new TrackVM();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.DeleteAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    TrackVM = JsonConvert.DeserializeObject<TrackVM>(apiResponse);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
