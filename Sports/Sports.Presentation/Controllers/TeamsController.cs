using Microsoft.AspNetCore.Mvc;

namespace Sports.Presentation.Controllers
{
    public class TeamsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }   
        public IActionResult AddTeam()
        {
            return View();
        }   
        public IActionResult EditTeam(int Id)
        {
            return View();
        }  
        public IActionResult FilterTeamByTournament()
        {
            return View();
        }
    }
}
