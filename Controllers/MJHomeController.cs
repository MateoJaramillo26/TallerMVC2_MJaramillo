using Microsoft.AspNetCore.Mvc;

namespace TallerMVC2_MJ.Controllers
{
    public class MJHomeController : Controller
    {
        public IActionResult MJIndex()
        {
            return View();
        }

        public IActionResult MJPrivacy()
        {
            return View();
        }
    }
}
