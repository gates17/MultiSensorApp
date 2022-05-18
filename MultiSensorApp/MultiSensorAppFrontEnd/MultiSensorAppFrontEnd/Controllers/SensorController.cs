using Microsoft.AspNetCore.Mvc;

namespace MultiSensorAppFrontEnd.Controllers
{
    public class SensorController : Controller
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
