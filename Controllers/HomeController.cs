using Disaster_Guide.Context;
using Disaster_Guide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace Disaster_Guide.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBcontext _context;

        public HomeController(ILogger<HomeController> logger, DBcontext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Please enter both username and password.";
                return View();
            }

            // Check the database for matching user credentials
            var user = _context.users.FirstOrDefault(u => u.username == username && u.password == password);

            if (user != null)
            {
                // Successful login
                return RedirectToAction("Map");
            }
            else
            {
                // Invalid login
                ViewBag.Error = "Invalid username or password.";
                return View();
            }
        }

        public IActionResult Map()
        {
            return View();
        }

        public IActionResult HomePage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
