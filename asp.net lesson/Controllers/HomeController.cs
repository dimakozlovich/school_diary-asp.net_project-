using asp.net_lesson.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using prototypedb;
namespace asp.net_lesson.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public Timetable timetable;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            var user = new User("kozlovichdima21@gmail.com", "dimaamid");
            timetable = new Timetable(user.Grade_id);
        }
        public IActionResult Index()
        {
            return View(timetable);
        }
        [HttpGet]
        public IActionResult Edit(DateTime date,int place_in_day,int place_in_week, int grade_id)
        {
           
            return View(timetable.FindSubject(place_in_day,  place_in_week, grade_id));
        }
        [HttpPost]
        public IActionResult Edit(DateTime date, int place_in_day, int place_in_week, int grade_id, string EditSubject, string EditHomework)
        {
            var timeTable = new Timetable(grade_id);
            if (timeTable.BoolExistenceCheck(place_in_week, place_in_day))
            {
                timeTable.EditSubject(date, place_in_day, place_in_week, grade_id, EditSubject, EditHomework);
            }
            else
            {
                timeTable.AddSubject(place_in_day, place_in_week, grade_id, EditSubject, EditHomework);
            }
            timetable.UpdateTimetable();
            return View("Index",timetable);
        }
        [HttpPost]
        public IActionResult Week(string week)
        {   
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public DateTime dateTimeNow()
        {
            DateTime dt = DateTime.Now;
            return dt;
        }

    }
}