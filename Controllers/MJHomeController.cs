using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TallerMVC2_MJ.Models;

namespace TallerMVC2_MJ.Controllers
{
    public class MJHomeController : Controller
    {
        private readonly ILogger<MJHomeController> _logger;

        public MJHomeController(ILogger<MJHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult MJIndex()
        {
            return View();
        }

        public IActionResult MJPrivacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new MJErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
