using Microsoft.AspNetCore.Mvc;

namespace MultiSensorAppFrontEnd.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
