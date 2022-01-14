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
    public class TeamController : Controller
    {
        public IConfiguration Configuration;
        private readonly HttpClientHandler clientHandler = new HttpClientHandler();

        public TeamController(IConfiguration configuration)
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

        // GET: TeamController
        public async Task<IActionResult> Index()
        {
            string _restpath = GetHostUrl().Content + CN();
            List<TeamVM> Teams = new List<TeamVM>();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Teams = JsonConvert.DeserializeObject<List<TeamVM>>(apiResponse);
                }
            }
            return View(Teams);
        }

        // GET: TeamController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: TeamController/Create
        public IActionResult Create()
        {
            TeamVM TeamVM = new TeamVM();
            return View(TeamVM);
        }

        // POST: TeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamVM TeamVM)
        {
            string _restpath = GetHostUrl().Content + CN();
            TeamVM result = new TeamVM();
            try
            {
                using (var httpClient = new HttpClient(clientHandler))
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(TeamVM);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(_restpath, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<TeamVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TeamController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            TeamVM TeamVM = new TeamVM();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    TeamVM = JsonConvert.DeserializeObject<TeamVM>(apiResponse);
                }
            }
            return View(TeamVM);
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeamVM TeamVM)
        {
            string _restpath = GetHostUrl().Content + CN();
            TeamVM result = new TeamVM();
            try
            {
                using (var httpClient = new HttpClient(clientHandler))
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(TeamVM);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{TeamVM.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<TeamVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TeamController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            TeamVM TeamVM = new TeamVM();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.DeleteAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    TeamVM = JsonConvert.DeserializeObject<TeamVM>(apiResponse);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
