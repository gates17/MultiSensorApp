using Microsoft.AspNetCore.Mvc;
using MultiSensorAppFrontEnd.Models;

namespace MultiSensorAppFrontEnd.Controllers
{
    public class RoleController : Controller
    {
        //List all
        public IActionResult Index()
        {
            IEnumerable<Role> roles = new List<Role> { new Role { Id=1, Type="SuperUser", Description= "This user can change all in a specific area" } };
            return View(roles);
            
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
