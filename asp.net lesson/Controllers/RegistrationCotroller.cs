using Microsoft.AspNetCore.Mvc;

namespace asp.net_lesson.Controllers
{
    public class RegistrationCotroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
    }
}
