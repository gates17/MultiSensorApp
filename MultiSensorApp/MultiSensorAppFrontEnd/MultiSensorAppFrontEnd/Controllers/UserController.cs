using Microsoft.AspNetCore.Mvc;
using MultiSensorAppFrontEnd.Models;

namespace MultiSensorAppFrontEnd.Controllers
{
    public class UserController : Controller
    {

        //List all
        public IActionResult Index()
        {
            return View();
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
