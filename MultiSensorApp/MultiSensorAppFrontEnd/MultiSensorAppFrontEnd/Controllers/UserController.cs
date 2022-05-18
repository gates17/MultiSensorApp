using Microsoft.AspNetCore.Mvc;
using MultiSensorAppFrontEnd.Models;

namespace MultiSensorAppFrontEnd.Controllers
{
    public class UserController : Controller
    {

        //List all
        public IActionResult Index()
        {
            IEnumerable<User> users = new List<User> { new User { Id=1, Name="João", EmailAdress="dfg@sdfg.pt"} };
            return View(users);
        }

        //Get by ID
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }

    }
}
