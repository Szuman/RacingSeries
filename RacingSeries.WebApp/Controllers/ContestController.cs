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
    public class ContestController : Controller
    {
        public IConfiguration Configuration;
        private readonly HttpClientHandler clientHandler = new HttpClientHandler();

        public ContestController(IConfiguration configuration)
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

        // GET: ContestController
        public async Task<IActionResult> Index()
        {
            string _restpath = GetHostUrl().Content + CN();
            List<ContestVM> Contests = new List<ContestVM>();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Contests = JsonConvert.DeserializeObject<List<ContestVM>>(apiResponse);
                }
            }
            return View(Contests);
        }

        // GET: ContestController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: ContestController/Create
        public IActionResult Create()
        {
            ContestVM ContestVM = new ContestVM();
            return View(ContestVM);
        }

        // POST: ContestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContestVM ContestVM)
        {
            string _restpath = GetHostUrl().Content + CN();
            ContestVM result = new ContestVM();
            try
            {
                using (var httpClient = new HttpClient(clientHandler))
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(ContestVM);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(_restpath, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<ContestVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ContestController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            ContestVM ContestVM = new ContestVM();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ContestVM = JsonConvert.DeserializeObject<ContestVM>(apiResponse);
                }
            }
            return View(ContestVM);
        }

        // POST: ContestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContestVM ContestVM)
        {
            string _restpath = GetHostUrl().Content + CN();
            ContestVM result = new ContestVM();
            try
            {
                using (var httpClient = new HttpClient(clientHandler))
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(ContestVM);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{ContestVM.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<ContestVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ContestController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            ContestVM ContestVM = new ContestVM();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.DeleteAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ContestVM = JsonConvert.DeserializeObject<ContestVM>(apiResponse);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
