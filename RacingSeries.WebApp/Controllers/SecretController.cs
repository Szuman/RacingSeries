using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RacingSeries.WebApp.Controllers
{
    [Authorize(Roles = "admin,Masi")]
    public class SecretController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
