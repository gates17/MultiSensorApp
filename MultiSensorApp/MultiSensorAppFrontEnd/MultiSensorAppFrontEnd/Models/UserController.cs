using Microsoft.AspNetCore.Mvc;

namespace MultiSensorAppFrontEnd.Models
{
    public class UserController : Controller
    {
        private readonly IConfiguration configuration;

        public UserController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        // GET: UserController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<User> users = await Models.User.GetUsers(configuration.GetValue<string>("URI"));
            return View(users);
        }
    }
}
