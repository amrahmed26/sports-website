using Microsoft.AspNetCore.Mvc;

namespace Sports.Controllers
{
    public class TournamentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult AddTournament()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EditTournament(int Id)
        {
            return View();
        }
    }
}
