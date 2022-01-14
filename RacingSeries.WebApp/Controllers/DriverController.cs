using Microsoft.AspNetCore.Http;
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
    public class DriverController : Controller
    {
        public IConfiguration Configuration;
        private readonly HttpClientHandler clientHandler = new HttpClientHandler();

        public DriverController(IConfiguration configuration)
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

        // GET: DriverController
        public async Task<IActionResult> Index()
        {
            string _restpath = GetHostUrl().Content + CN();
            List<DriverVM> drivers = new List<DriverVM>();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    drivers = JsonConvert.DeserializeObject<List<DriverVM>>(apiResponse);
                }
            }
            return View(drivers);
        }

        // GET: DriverController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: DriverController/Create
        public IActionResult Create()
        {
            DriverVM driverVM = new DriverVM();
            return View(driverVM);
        }

        // POST: DriverController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DriverVM driverVM)
        {
            string _restpath = GetHostUrl().Content + CN();
            DriverVM result = new DriverVM();
            try
            {
                using (var httpClient = new HttpClient(clientHandler))
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(driverVM);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(_restpath, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<DriverVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DriverController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            DriverVM driverVM = new DriverVM();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    driverVM = JsonConvert.DeserializeObject<DriverVM>(apiResponse);
                }
            }
            return View(driverVM);
        }

        // POST: DriverController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DriverVM driverVM)
        {
            string _restpath = GetHostUrl().Content + CN();
            DriverVM result = new DriverVM();
            try
            {
                using (var httpClient = new HttpClient(clientHandler))
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(driverVM);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{driverVM.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<DriverVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DriverController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            DriverVM driverVM = new DriverVM();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.DeleteAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    driverVM = JsonConvert.DeserializeObject<DriverVM>(apiResponse);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: DriverController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
